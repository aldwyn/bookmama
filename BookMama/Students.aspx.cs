using BookMama.Context;
using BookMama.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (ResourceContext db = new ResourceContext())
            {
                string currUser = User.Identity.GetUserId();
                var ms = db.StudentsContext.Where(r => r.MentorId == currUser).Select(r => r.StudentId).ToList();
            }
        }
    }
}