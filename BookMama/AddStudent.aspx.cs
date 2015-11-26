using BookMama.Context;
using BookMama.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = DateTime.Now.ToString().GetHashCode().ToString("x");
            Password.Attributes.Add("value", code);
        }

        protected void SaveStudent(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                using (ResourceContext db = new ResourceContext())
                {
                    MentorStudent ms = new MentorStudent
                    {
                        MentorId = User.Identity.GetUserId(),
                        StudentId = user.Id,
                        DateInvited = DateTime.Now
                    };
                    db.StudentsContext.Add(ms);
                    db.SaveChanges();
                }
                Response.Redirect("Students");
            }
        }
    }
}