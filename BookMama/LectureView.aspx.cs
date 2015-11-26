﻿using BookMama.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class LectureView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int lectureId = Convert.ToInt32(Request.QueryString["Id"]);
            using (ResourceContext db = new ResourceContext())
            {
                Lecture lecture = db.LecturesContext.Find(lectureId);
                LectureTitle.Text = lecture.Title;
                LectureNotes.Text = lecture.Notes;
                DateCreated.Text = lecture.DateCreated.ToString();
                MaterialsList.DataSource = db.MaterialsContext.Where(m => m.LectureId == lectureId).ToList();
                MaterialsList.DataBind();
                if (MaterialsList.Rows.Count > 0)
                {
                    MaterialsList.UseAccessibleHeader = true;
                    MaterialsList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                MaterialsList.GridLines = GridLines.None;
                EditLectureLink.NavigateUrl = "EditLecture.aspx?Id=" + lectureId;
            }
        }
    }
}