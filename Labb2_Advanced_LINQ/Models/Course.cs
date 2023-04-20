    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Advanced_LINQ.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
