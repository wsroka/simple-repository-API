using Dapper;
using simple_repository_API.Models;
using System.Data.SqlClient;

namespace simple_repository_API
{
    public class StudentRepository
    {
        private readonly SqlConnection _connection;

        public StudentRepository()
        {
            _connection = new SqlConnection(
                   @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = school; Trusted_Connection = True;");
        }
        public Student GetStudent(int id) => _connection.QuerySingle<Student>("SELECT ID_Student,Name,Surname,Age FROM Student WHERE ID_Student = @Id", new { @Id = id });

        public List<Student> GetStudents() => _connection.Query<Student>("SELECT ID_Student,Name,Surname,Age FROM Student").ToList();

        public void InsertStudent(Student student) => _connection.Execute("INSERT INTO Student (ID_Student, Name, Surname, Age) VALUES (@ID_Student, @Name, @Surname, @Age)", student);

        public void DeleteStudent(int id) => _connection.Execute("DELETE FROM Student WHERE ID_Student = @Id", new { @Id = id });

        public void UdateStudent(Student student) => _connection.Execute("Update Student SET Name = @Name, Surname = @Surname, Age = @Age WHERE ID_Student = @Id", student);
    }
}
