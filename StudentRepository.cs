using Microsoft.Identity.Client;
using PassTheDataFromModelMVC.Context;
using PassTheDataFromModelMVC.Models;
using System.Xml.Linq;

namespace PassTheDataFromModelMVC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> student;

        private readonly StudentDbContext context;

        public StudentRepository(StudentDbContext  studentDbContext)
        {
            context= studentDbContext;
        }

        /*
        public StudentRepository()
        {
            student = new List<Student>()
            {
                new Student() {  StudId = 1, Name = "Sonam", Semester = 8, Branch = "CSE" },
                new Student() {StudId=2,Name="Sia",Semester=5,Branch="CSE" },
                new Student() {StudId=3,Name="Sonu",Semester=4,Branch="CSE" }
            };
        }
        */

        public Student add(Student student)
        {
            context.students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student delete(int StudId)
        {
            Student student = context.students.Find(StudId);
            if (student!= null) 
            {   
                context.students.Remove(student);
                context.SaveChanges() ;
            }

            return student;

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.students;
        }

        public Student getStudentById(int StudId)
        {
            return context.students.Find(StudId);
        }


        public Student update(Student modifiedStudent)
        {
            context.Update(modifiedStudent);
            context.SaveChanges();
            return modifiedStudent;
        }
    }
}
