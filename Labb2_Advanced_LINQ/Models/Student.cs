using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Advanced_LINQ.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
