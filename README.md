# BookMama - an E-learning platform built on top of ASP.NET Web Forms

![BookMama Home Page](https://github.com/aldwyn/bookmama/blob/master/homepage.png "BookMama Home Page")

![BookMama Lecture View](https://github.com/aldwyn/bookmama/blob/master/lectureview.png "Lecture View")

### Technologies Used:
- ASP.NET 4.5 Web Forms
- Twitter Bootstrap 3.3.6
- SendGrid

### User Stories:
- As a Mentor, I can register myself as a Mentor
- As a Mentor, I can confirm my email upon registration
- As a Mentor, I can log in to the site
- As a Mentor, I can reset my password using "Forgot my password"
- As a Mentor, I can log out from the site
- As a Mentor, I can post new lectures
- As a Mentor, I can view all my lectures
- As a Mentor, I can edit my lectures
- As a Mentor, I can delete my lectures
- As a Mentor, I can upload materials on my lectures
- As a Mentor, I can add a Student
- As a Mentor, I can view all my Students
- As a Student, I can confirm my email upon receiving my Mentor's invite
- As a Student, I can login to the site
- As a Student, I can view my Mentor's lectures
- As a Student, I can download my Mentor's materials


### What have I done?
- I have used Secure Socket Layer (SSL) to my site for secured browsing.
- I have used ASP.NET Identity Framework for implementing ASP.NET-compatible user registration, authentication and authorization.
- I have designed the app to upload binary materials not to the database, but to the "resources" folder in the root directory.
- I have used SendGrid for automated email service in ASP.NET


### What have I learned?
- I have learned that web forms are a complete package of a view, code-behind, and a designer.
- I have learned that it is not encouraged to save BLOB files to the database because it will just create a large overhead upon access and modification, which will cause for the app to be unresponsive at times.
- I have learned that it is not encouraged to link a stylesheet into an email HTML message because some secured email services blocks them upon being transported to the recipient.


### What are the challenges?
- I have had hard times on linking my Lecture entities onto users because of the deep implementation of ASP.NET's Identity Framework.
- I have had hard times in achieving relationship binding of Material entities onto Lecture entities because of unfamiliarity to Entity Framework.