using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Advanced_LINQ.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-T8D7ORFB; Initial Catalog = Labb2_Advanced_Linq; Integrated Security = True;");
        }
    }
}
