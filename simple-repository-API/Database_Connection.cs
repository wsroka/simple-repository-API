using simple_repository_API.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace simple_repository_API

{
    public class Database_Connection
    {
        public List<Student> Database_connect() 
        {
            List <Student> students = new List <Student>();

            using (SqlConnection connection = new SqlConnection(
                   @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = school; Trusted_Connection = True;"))
            {
                connection.Open();
                string queryString = "SELECT ID_Student,Name,Surname,Age FROM Student";
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID_Student = reader.GetInt32(0);
                    student.Name = reader.GetString(1);
                    student.Surname = reader.GetString(2);
                    student.Age = reader.GetInt32(3);

                    students.Add(student);
                }
                reader.Close();
            }
            return students;

        }
        public void Database_Insert(Student student)
        {
            
            using (SqlConnection connection = new SqlConnection(
               @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = school; Trusted_Connection = True;"))
            {
                connection.Open();
                var sql = "INSERT INTO Student (ID_Student, Name, Surname, Age) VALUES (@ID_Student, @Name, @Surname, @Age)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID_Student", student.ID_Student);
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
