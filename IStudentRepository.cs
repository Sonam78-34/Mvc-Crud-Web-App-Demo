using PassTheDataFromModelMVC.Models;

namespace PassTheDataFromModelMVC.Repository
{
    public interface IStudentRepository
    {
        public Student add(Student student);
        public Student update(Student student);
        public Student delete(int StudId);

        public Student getStudentById(int StudId);
        
        IEnumerable<Student> GetAllStudents();

    }
}
