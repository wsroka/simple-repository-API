using simple_repository_API.Models;

namespace simple_repository_API
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        List<Student> GetStudents();
        void InsertStudent(Student student);
        void DeleteStudent(int id);
        void UpdateStudent(Student student);
    }
}
