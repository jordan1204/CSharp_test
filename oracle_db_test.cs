using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "User Id=sajet;Password=tech;Data Source=192.168.1.103:1521/ORCL4;";

            var connection = new OracleConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
SELECT
    name
FROM EMS_ACCOUNT
";

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            connection.Close();
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
        }
    }
}
