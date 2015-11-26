namespace BookMama
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        public int Id { get; set; }

        [Required]
        public string Filename { get; set; }

        public DateTime DateUploaded { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; }

        public int ContentLength { get; set; }
        
        public int LectureId { get; set; }

        public int DownloadTimes { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}
