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

        [HttpPost("GetStudents")]
        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        [HttpDelete("DeleteStudent")]
        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
