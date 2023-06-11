using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using PassTheDataFromModelMVC.Models;
using PassTheDataFromModelMVC.Repository;

namespace PassTheDataFromModelMVC.Controllers
{
    public class StudentDetailsController : Controller
    {
        private readonly IStudentRepository studentRepo;

        public StudentDetailsController(IStudentRepository StudentRepository)
        {
            studentRepo = StudentRepository;
        }
        
        public IActionResult studentInfo()
        {
            var students= studentRepo.GetAllStudents();
            /*
            var students = new List<Student>
            { new Student {StudId=1,Name="Sonam",Semester=8,Branch="CSE" },
              new Student {StudId=2,Name="Sia",Semester=5,Branch="CSE" },

            };
            ViewData["students"] = students;
            */
            return View(students);

        }

        [HttpGet]
        public IActionResult CreateStudentDetails() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudentDetails(Student student )
        {
            Student newStudent = studentRepo.add(student);
                return RedirectToAction("studentInfo");
        }


        public IActionResult Delete(int StudId)
        {
            Student student = studentRepo.delete(StudId);
            return RedirectToAction("studentInfo");
        }


        [HttpGet]

        public IActionResult editStudent(int StudId) 
        { 
            Student student= studentRepo.getStudentById(StudId);
            return View(student);
        
        }

        [HttpPost]
        public IActionResult editStudent(Student modifiedStudent)
        {
            Student student = studentRepo.getStudentById(modifiedStudent.StudId);

            //add the changes
            student.Name = modifiedStudent.Name;
            student.Semester = modifiedStudent.Semester;
            student.Branch = modifiedStudent.Branch;
            //for update
            Student updateStudent= studentRepo.update(student);
            return RedirectToAction("studentInfo");

        }

        private IActionResult RedirectToAction(Func<IActionResult> studentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
