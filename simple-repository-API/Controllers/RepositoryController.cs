using Microsoft.AspNetCore.Mvc;
using simple_repository_API.Models;

namespace simple_repository_API.Controllers
{
    public class RepositoryController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public RepositoryController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
            _studentRepository.UpdateStudent(student);
        }
    }
}
