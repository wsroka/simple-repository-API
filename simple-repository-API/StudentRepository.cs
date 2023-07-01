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
            var student = new Student();
            var parameters = new Dictionary<string, object>();
            parameters["@Id"] = id;
            var reader = ExecuteSql("SELECT Id_Student,Name,Surname,Age FROM Student WHERE Id_Student = @Id", parameters);

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

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            _connection.Open();
            string query = "SELECT Id_Student,Name,Surname,Age FROM Student";
            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var student = new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Age = reader.GetInt32(3)
                };
                students.Add(student);
            }
            _connection.Close();

            return students;
        }

        public void InsertStudent(Student student)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@Id", student.Id },
                { "@Name", student.Name},
                { "@Surname", student.Surname},
                { "@Age", student.Age}
            };
            ExecuteSql("INSERT INTO Student (ID_Student, Name, Surname, Age) VALUES (@Id, @Name, @Surname, @Age)", parameters);
        }
        public void DeleteStudent(int id)
        {
            _connection.Open();
            var query = "DELETE FROM Student WHERE ID_Student = @ID";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        private SqlDataReader ExecuteSql(string sql, Dictionary<string, object> parameters)
        {
            _connection.Open();
            var command = new SqlCommand(sql, _connection);
            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }
            return command.ExecuteReader();
        }

    }
}
