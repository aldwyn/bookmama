namespace BookMama
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecture
    {
        public Lecture ()
        {
            Materials = new List<Material>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Notes { get; set; }

        public DateTime DateCreated { get; set; }
        
        public string AuthorId { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
