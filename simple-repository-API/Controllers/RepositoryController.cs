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

        [HttpPost("StudentsList")]
        public List <Student> GetStudentsLists()
        {
            return _studentRepository.GetStudentsList();
        }
    }
}
