using Labb2_Advanced_LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Advanced_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AddingData.CallMethod();
            MainMenu();
        }
        static void MainMenu()
        {
            Context myContext=new Context();
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Select an option between 1-6");
                Console.WriteLine("1. Get all teachers teaching math");
                Console.WriteLine("2. Get all students");
                Console.WriteLine("3. Check if subjects contains programing1");
                Console.WriteLine("4. Change subject Social studies to OOP");
                Console.WriteLine("5. Update a student record if their teacher is Anas to Reidar");
                Console.WriteLine("6. End Program\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        GetMathTeachers(myContext);
                        break;
                    case "2":
                        GetAllStudents(myContext);
                        break;
                    case "3":
                        IfContainsSubject(myContext);
                        break;
                    case "4":
                        EditSubject(myContext);
                        break;
                    case "5":
                        UpdateStudentTeacher(myContext);
                        break;
                    case "6":
                        end = true;
                        break;
                    default:
                        Console.WriteLine("That is not an option");
                        break;
                }
            }
        }
        static void GetMathTeachers(Context myContext)
        {
            var AllMathTeachers = myContext.Subjects.Where(c => c.SubjectName == "Math").SelectMany(c => c.Teachers).ToList();
            foreach(var item in AllMathTeachers)
            {
                Console.WriteLine("Teacher Name : {0}, Teacher ID: {1}\n",item.TeacherName,item.TeacherID);
            }
        }
        static void GetAllStudents(Context myContext)
        {
            var AllStudents = (myContext.Students.Include(c=>c.Teacher));
            foreach (var item in AllStudents)
            {
                Console.WriteLine("Student ID : {0}, Student Name : {1}, Students Teacher : {2}\n",item.StudentID,item.StudentName,item.Teacher.TeacherName);
            }
        }
        static void IfContainsSubject(Context myContext)
        {
            string test = "Programming1";
            var checking = (myContext.Subjects.Where(c => c.SubjectName == test).FirstOrDefault());
            if(checking != null)
            {
                Console.WriteLine("The subject {0} does exist in the database\n",checking.SubjectName);
            }
            else
            {
                Console.WriteLine("The subject does not exist in the database\n");
            }
        }
        static void EditSubject(Context myContext)
        {
            string test = "Social studies";
            var findingSubject=(myContext.Subjects.Where(c => c.SubjectName == test).FirstOrDefault());
            if(findingSubject != null)
            {
                findingSubject.SubjectName = "OOP";
                myContext.SaveChanges();
                Console.WriteLine("Subject {0} was changed into {1}", test, findingSubject.SubjectName);
            }
            else
            {
                Console.WriteLine("Could not find that subject");
            }
        }
        static void UpdateStudentTeacher(Context myContext)
        {
            string newTeacher = "Reidar";
            string find = "Anas";

            var findTeacher=(myContext.Teachers.Where(c => c.TeacherName == find).SelectMany(c=>c.Students).First());
            var ChangeTeacher = (myContext.Teachers.Where(c => c.TeacherName == newTeacher).First());
            if(findTeacher != null)
            {
                findTeacher.Teacher = ChangeTeacher;
                myContext.SaveChanges();
                Console.WriteLine("Student {0} teacher changed from {1} to {2}",findTeacher.StudentName,find,ChangeTeacher.TeacherName);
            }
            else
            {
                Console.WriteLine("Could not find a student with teacher {0}",find);
            }
        }
    }
}