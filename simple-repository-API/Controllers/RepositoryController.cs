using Microsoft.AspNetCore.Mvc;
using simple_repository_API.Models;

namespace simple_repository_API.Controllers
{
    public class RepositoryController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public RepositoryController()
        {
            _studentRepository = new StudentRepository();
        }

        [HttpGet("Student")]
        public Student GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }

        [HttpGet("GetStudents")]
        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        [HttpDelete("DeleteStudent")]
        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
        [HttpPost("InsertStudent")]
        public void InsertStudent(Student student)
        {
            _studentRepository.InsertStudent(student);
        }
        [HttpPost("UpdateStudent")]
        public void UpdateStudent(Student student)
        {
            _studentRepository.UdateStudent(student);
        }
    }
}
