using BookMama.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookMama
{
    public partial class Material1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int materialId = Convert.ToInt32(Request.QueryString["Id"]);
            using (ResourceContext db = new ResourceContext())
            {
                DataBind();
                Material material = db.MaterialsContext.Find(materialId);
                Filename.Text = material.Filename;
                string source = "resources/" + material.Lecture.AuthorId + "/" + material.Filename;
                if (material.ContentType.StartsWith("image"))
                {
                    RenderedContent.Text = "<img src='" + source + "' />";
                } else if (material.ContentType == "application/pdf")
                {
                    RenderedContent.Text = "<embed style='width: 100%; height: 600px;' src='" + source + "' type='application/pdf'>";
                } else if (material.ContentType.StartsWith("video"))
                {
                    string sourceTag = "<source src='" + source + "' type='" + material.ContentType + "'>";
                    RenderedContent.Text = "<video style='width: 100%; height: auto;' preload='auto' controls>" + sourceTag + "</video>";
                } else if (material.ContentType.StartsWith("audio"))
                {
                    string sourceTag = "<source src='" + source + "' type='" + material.ContentType + "'>";
                    RenderedContent.Text = "<audio style='width: 100%; height: auto;' preload='auto' controls>" + sourceTag + "</audio>";
                } else
                {
                    RenderedContent.Text = "<div class='well'>The material is not supported for previewing.</div>";
                }
                DetailFilename.Text = material.Filename;
                DetailLength.Text = material.ContentLength + " bytes";
                DetailType.Text = material.ContentType;
                DetailLecture.Text = material.Lecture.Title;
                DetailLecture.NavigateUrl = "LectureView.aspx?Id=" + material.LectureId;
                DetailSource.Value = source;
                DownloadTimes.Text = "Downloaded " + material.DownloadTimes + " times.";
                DetailId.Value = materialId.ToString();
            }
        }

        protected void DownloadMaterial(object sender, EventArgs e)
        {
            Response.ContentType = DetailType.Text;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + DetailFilename.Text);
            Response.TransmitFile(Server.MapPath(DetailSource.Value));
            Response.End();
            using (ResourceContext db = new ResourceContext())
            {
                int materialId = Convert.ToInt32(DetailId.Value);
                Material material = db.MaterialsContext.Find(materialId);
                material.DownloadTimes = material.DownloadTimes + 1;
                db.Entry(material).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}