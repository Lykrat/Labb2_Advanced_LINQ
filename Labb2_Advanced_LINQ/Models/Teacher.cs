using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Advanced_LINQ.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
