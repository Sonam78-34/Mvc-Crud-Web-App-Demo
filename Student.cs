using System.ComponentModel.DataAnnotations;

namespace PassTheDataFromModelMVC.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Branch { get; set; }
    }
}
