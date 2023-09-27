using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace simple_repository_API.Models
{
    public class DBConfiguration
    {
        public static string ConnectionString { get; set; }
    }
}
