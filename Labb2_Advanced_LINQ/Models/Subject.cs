using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Advanced_LINQ.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
