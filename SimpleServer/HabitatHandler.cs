using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SimpleServer
{
    public class HabitatHandler
    {
        public HabitatHandler()
        {
        }

        public string getHabitat(string IdHabitat)
        {
            string response = "";
            string query = @"
            SELECT
                h.IdHabitat,
                h.Name,
                h.CurrentlyOpen,
                ht.Name
            FROM Habitat h
            INNER JOIN HabitatType ht ON h.IdHabitatType = ht.IdHabitatType
            WHERE h.IdHabitat = " + IdHabitat;

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
                response += "<div class=\"habitat habitat-id-" + reader[0] + "\">";
                response += "<h2>" + reader[1] + "</h2>";
                response += "<div>One of the " + reader[3] + " habitats</div>";
                response += "<div> Currently open: " + reader[2] + "</div>";
                response += "</div>";
            }
            Console.WriteLine(response);

            // clean up
            reader.Dispose();
            dbcmd.Dispose();
            dbcon.Close();

            return response;
        }

        public string GetAllHabitats()
        {
            string response = "";
            string query = @"
            SELECT
                h.IdHabitat,
                h.Name,
                h.CurrentlyOpen,
                ht.Name
            FROM Habitat h
            INNER JOIN HabitatType ht ON h.IdHabitatType = ht.IdHabitatType";

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
                response += "<div class=\"habitat habitat-id-" + reader[0] + "\">";
                response += "<h2>" + reader[1] + "</h2>";
                response += "<div>One of the " + reader[3] + " habitats</div>";
                response += "<div> Currently open: " + reader[2] + "</div>";
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
