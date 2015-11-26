using BookMama.Context;
using BookMama.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class Lectures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ResourceContext db = new ResourceContext())
            {
                string currentUser = User.Identity.GetUserId();
                LecturesList.DataSource = db.LecturesContext
                    .Where(l => l.AuthorId == currentUser)
                    .OrderByDescending(l => l.DateCreated).ToList();
                LecturesList.DataBind();
            }
            if (LecturesList.Rows.Count > 0)
            {
                LecturesList.UseAccessibleHeader = true;
                LecturesList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            LecturesList.GridLines = GridLines.None;

        }
        
        protected void LecturesList_RowEditing(object sender, EventArgs e)
        {
            Response.Redirect("Lectures");
        }

        protected void LecturesList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (ResourceContext db = new ResourceContext())
            {
                Lecture lecture = db.LecturesContext.Find(e.Keys[0]);
                db.LecturesContext.Remove(lecture);
                db.SaveChanges();
            }
            Response.Redirect("Lectures");
        }

        protected void LecturesList_Sorting(object sender, EventArgs e)
        {
            Response.Redirect("Lectures");
        }
    }
}