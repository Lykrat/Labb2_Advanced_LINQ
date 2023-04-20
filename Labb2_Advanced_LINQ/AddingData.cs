using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2_Advanced_LINQ.Models;

namespace Labb2_Advanced_LINQ
{
    public class AddingData
    {
        public static void CallMethod()
        {
            StartAddData();
        }
        static void StartAddData()
        {
            var course1 = new Course() { CourseName = "SUT22" };
            var course2 = new Course() { CourseName = "SUT21" };

            ICollection<Course> courseSub1 = new List<Course> { course1, course2};
            ICollection<Course> courseSub2 = new List<Course> { course1, course2};
            ICollection<Course> courseSub3 = new List<Course> { course2};

            var teacher1 = new Teacher() {TeacherName="Tobias" };
            var teacher2 = new Teacher() { TeacherName = "Reidar" };
            var teacher3 = new Teacher() { TeacherName = "Anas" };

            ICollection<Teacher> teacherSub1 = new List<Teacher> { teacher1, teacher3 };
            ICollection<Teacher> teacherSub2 = new List<Teacher> { teacher1, teacher2,teacher3 };
            ICollection<Teacher> teacherSub3 = new List<Teacher> { teacher2};



            var subject1 = new Subject() { SubjectName = "Math",Teachers=teacherSub1,Courses=courseSub1 };
            var subject2 = new Subject() { SubjectName = "Programming1", Teachers = teacherSub2, Courses = courseSub1 };
            var subject3 = new Subject() { SubjectName = "Social studies", Teachers = teacherSub3, Courses = courseSub1 };

            var student1 = new Student() { StudentName = "Emil", Teacher = teacher3, Course = course1 };
            var student2 = new Student() { StudentName = "Lucas", Teacher = teacher1, Course = course1 };
            var student3 = new Student() { StudentName = "Theo", Teacher = teacher2, Course = course2 };
            var student4 = new Student() { StudentName = "Filip", Teacher = teacher2, Course = course2 };
            var student5 = new Student() { StudentName = "Edvin", Teacher = teacher3, Course = course1 };

            using (var context=new Context())
            {
                context.Courses.AddRange(course1, course2);
                context.Teachers.AddRange(teacher1, teacher2, teacher3);
                context.Subjects.AddRange(subject1, subject2, subject3);
                context.Students.AddRange(student1, student2, student3, student4, student5);

                context.SaveChanges();
            }

            Console.WriteLine("success");
        }
    }
}
