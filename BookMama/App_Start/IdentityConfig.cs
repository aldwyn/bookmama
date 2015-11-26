using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using BookMama.Models;
using System.Configuration;
using System.Net;
using SendGrid;
using System.Net.Mail;
using System.Diagnostics;

namespace BookMama
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            await ConfigSendGridAsync(message);
        }

        public async Task ConfigSendGridAsync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("admin@BookMama", "BookMama Admin");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = "<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                    "<title>BookMama Invitation</title>" +
                    "<meta charset=\"utf-8\" />" +
                "</head>" +
                "<body>" +
                    "<div class=\"navbar navbar-inverse navbar-fixed-top\">" +
                        "<div class=\"container\">" +
                            "<div class=\"navbar-header\">" +
                                "<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">" +
                                    "<span class=\"icon-bar\"></span>" +
                                    "<span class=\"icon-bar\"></span>" +
                                    "<span class=\"icon-bar\"></span>" +
                                "</button>" +
                                "<a class=\"navbar-brand\" href=\"~/\">" +
                                    "<span class=\"glyphicon glyphicon-paperclip\"></span>" +
                                    "<span>BookMama</span>" +
                                "</a>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "<div class=\"container body-content\" style=\"margin-top: 50px\">" +
                        "<div class=\"page-header\">" +
                            "<h1>You have been invited to join BookMama!</h1>" +
                        "</div>" +
                        "<div class=\"jumbotron\">" +
                            "<h1>Hello, " + message.Destination + "!</h1>" +
                            "<p> All you have to do is confirm your email address for full membership of the new generation of E - learning, the BookMama!</p>" +
                               "<p><a class=\"btn btn-primary btn-lg\" href=\"#\" role=\"button\">Confirm Email</a></p>" +
                           "</div>" +
                           "<footer>" +
                               "<p>&copy; 2015. Aldwyn Technologies. All rights reserved.</p>" +
                           "</footer>" +
                       "</div>" +
                   "</body>" +
                   "</html>";

            var credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SendGridUsername"],
                ConfigurationManager.AppSettings["SendGridPassword"]
            );
            var transportWeb = new Web(credentials);

            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
