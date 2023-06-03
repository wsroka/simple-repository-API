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

        public Student GetStudent(int id)
        {
            Student student = new Student();

            _connection.Open();
            string query = "SELECT Id_Student,Name,Surname,Age FROM Student WHERE Id_Student = @Id";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Id", id);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                student = new Student()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Age = reader.GetInt32(3)
                };
            }

            return student;
        }

        public void Database_Insert(Student student)
        {

            using (SqlConnection connection = new SqlConnection(
               @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = school; Trusted_Connection = True;"))
            {
                connection.Open();
                var sql = "INSERT INTO Student (ID_Student, Name, Surname, Age) VALUES (@ID_Student, @Name, @Surname, @Age)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID_Student", student.Id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Surname", student.Surname);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.ExecuteNonQuery();
            }
        }
        public void Database_Delete(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(
               @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = school; Trusted_Connection = True;"))
            {
                connection.Open();
                var sqlDelete = "DELETE FROM Student WHERE ID_Student = @ID_Student";

                SqlCommand command = new SqlCommand(sqlDelete, connection);
                command.Parameters.AddWithValue("@ID_Student", studentId);
                command.ExecuteNonQuery();
            }
        }

    }
}
