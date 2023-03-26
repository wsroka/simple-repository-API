using System.Collections.Generic;
using System.Data.SqlClient;
namespace simple_repository_API
{
    public class Database_Connection
    {
        public Database_Connection() 
        {
            using (SqlConnection connection = new SqlConnection(
                   @"Server = Laptop-SS4D3ECJ\SQLEXPRESS; Database = shool; Trusted_Connection = True;"))
            {
                string queryString = "SELECT ID_Student,Name,Surname,Age FROM Student";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
