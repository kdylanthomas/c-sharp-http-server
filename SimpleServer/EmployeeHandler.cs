using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServer
{
    public class EmployeeHandler
    {
        public EmployeeHandler()
        {
        }

        public string GetEmployee(string IdEmployee)
        {
            string response = "";

            string query = @"
				SELECT 
				  e.IdEmployee,
				  e.Name, 
				  e.Age,
				  h.Name
				FROM Employee e
				INNER JOIN Habitat h ON e.IdEmployee = h.IdEmployee
				WHERE e.IdEmployee = 
				" + IdEmployee;

            const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "\"C:\\Users\\dylan\\Documents\\Visual Studio 2015\\Projects\\Zoolandia\\Zoolandia\\Zoolandia\\ZoolandiaDatabase.mdf\";Integrated Security=True";

            System.Data.IDbConnection dbcon = new SqlConnection(connectionString);

            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            dbcon.CreateCommand();

            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();

            // Read advances to the next row.
            while (reader.Read())
            {
                response += "<div class=\"employee employee-id-" + reader[0] + "\">";
                response += "<h2>" + reader[1] + "</h2>";
                response += "<div>" + reader[2] + " years old</div>";
                response += "<div>Works in the " + reader[3] + " habitat</div>";
                response += "</div>";
            }
            Console.WriteLine(response);

            // clean up
            reader.Dispose();
            dbcmd.Dispose();
            dbcon.Close();

            return response;
        }

        public string GetAllEmployees()
        {
            string response = "";

            string query = @"
				SELECT 
				  e.IdEmployee,
				  e.Name, 
				  e.Age,
				  h.Name
				FROM Employee e
				INNER JOIN Habitat h ON e.IdEmployee = h.IdEmployee";

            const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "\"C:\\Users\\dylan\\Documents\\Visual Studio 2015\\Projects\\Zoolandia\\Zoolandia\\Zoolandia\\ZoolandiaDatabase.mdf\";Integrated Security=True";

            System.Data.IDbConnection dbcon = new SqlConnection(connectionString);

            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            dbcon.CreateCommand();

            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();

            // Read advances to the next row.
            while (reader.Read())
            {
                response += "<div class=\"employee employee-id-" + reader[0] + "\">";
                response += "<h2>" + reader[1] + "</h2>";
                response += "<div>" + reader[2] + " years old</div>";
                response += "<div>Works in the " + reader[3] + " habitat</div>";
                response += "</div>";
            }
            Console.WriteLine(response);

            // clean up
            reader.Dispose();
            dbcmd.Dispose();
            dbcon.Close();

            return response;
        }
    }
}
