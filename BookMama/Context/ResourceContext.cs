using BookMama.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookMama.Context
{
    public class ResourceContext : DbContext
    {
        public ResourceContext() : base("DefaultConnection")
        {

        }

        public DbSet<Lecture> LecturesContext { get; set; }

        public DbSet<Material> MaterialsContext { get; set; }

        public DbSet<MentorStudent> StudentsContext { get; set; }

    }
}