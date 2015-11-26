using BookMama.Context;
using BookMama.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class AddLecture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaterialInput.Attributes.Add("accept", ".pdf,image/*,audio/*,video/*");
        }

        protected void SaveLecture(object sender, EventArgs e)
        {
            string savePath = Server.MapPath("~/resources/" + User.Identity.GetUserId() + "/");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (MaterialInput.HasFiles)
            {
                if (ModelState.IsValid)
                {
                    using (ResourceContext db = new ResourceContext())
                    {
                        Lecture lecture = new Lecture
                        {
                            Title = LectureTitle.Text,
                            Notes = NotesTextBox.Text,
                            DateCreated = DateTime.Now,
                            AuthorId = User.Identity.GetUserId()
                        };
                        foreach (HttpPostedFile uploadedFile in MaterialInput.PostedFiles)
                        {
                            uploadedFile.SaveAs(Path.Combine(savePath, uploadedFile.FileName));
                            Material material = new Material
                            {
                                Filename = uploadedFile.FileName,
                                ContentType = uploadedFile.ContentType,
                                ContentLength = uploadedFile.ContentLength,
                                DateUploaded = DateTime.Now
                            };
                           lecture.Materials.Add(material);
                        }
                        db.LecturesContext.Add(lecture);
                        db.SaveChanges();
                    }
                }
            }
            Response.Redirect("Lectures");
        }
    }
}