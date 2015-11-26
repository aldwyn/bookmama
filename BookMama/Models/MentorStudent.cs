namespace BookMama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MentorStudent")]
    public partial class MentorStudent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string MentorId { get; set; }

        [Required]
        [StringLength(128)]
        public string StudentId { get; set; }

        public DateTime DateInvited { get; set; }
        
    }
}
