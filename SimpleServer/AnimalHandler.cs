using System;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServer
{
	public class AnimalHandler
	{
		public AnimalHandler ()
		{
		}

		public string getAnimal(string IdAnimal) {
			string response = "";

			string query = @"
				SELECT 
				  a.IdAnimal,
				  a.Name, 
				  h.Name HabitatName,
				  ht.Name HabitatType,
				  s.CommonName,
				  s.ScientificName
				FROM Animal a
				INNER JOIN Species s ON a.IdSpecies = s.IdSpecies
				INNER JOIN Habitat h ON h.IdHabitat = a.IdHabitat
				INNER JOIN HabitatType ht on ht.IdHabitatType = h.IdHabitatType
				WHERE a.IdAnimal = 
				" + IdAnimal;

            const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "\"C:\\Users\\dylan\\Documents\\Visual Studio 2015\\Projects\\Zoolandia\\Zoolandia\\Zoolandia\\ZoolandiaDatabase.mdf\";Integrated Security=True";

            System.Data.IDbConnection dbcon = new SqlConnection(connectionString);

			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();
			dbcon.CreateCommand ();

			dbcmd.CommandText = query;
			IDataReader reader = dbcmd.ExecuteReader();

			// Read advances to the next row.
			while (reader.Read())
			{
				response += "<div class=\"animal animal-id-"+reader[0]+"\">";
				response += "<h2>" + reader[1] + "</h2>";
				response += "<div>" + reader[5] + "</div>";
				response += "<div>Lives in the "+ reader[2] +" ("+ reader[3] +" type) habitat</div>";
				response += "</div>";
			}
			Console.WriteLine(response);

			// clean up
			reader.Dispose();
			dbcmd.Dispose();
			dbcon.Close();

			return response;
		}


		public string getAllAnimals() {
			string response = "";

			const string query = @"
				SELECT 
				  a.IdAnimal,
				  a.Name, 
				  h.Name HabitatName,
				  ht.Name HabitatType,
				  s.CommonName,
				  s.ScientificName
				FROM Animal a
				INNER JOIN Species s ON a.IdSpecies = s.IdSpecies
				INNER JOIN Habitat h ON h.IdHabitat = a.IdHabitat
				INNER JOIN HabitatType ht on ht.IdHabitatType = h.IdHabitatType
				";

            const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ "\"C:\\Users\\dylan\\Documents\\Visual Studio 2015\\Projects\\Zoolandia\\Zoolandia\\Zoolandia\\ZoolandiaDatabase.mdf\";Integrated Security=True";
        System.Data.IDbConnection dbcon = new SqlConnection(connectionString);

			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();
			dbcon.CreateCommand ();

			dbcmd.CommandText = query;
			IDataReader reader = dbcmd.ExecuteReader();

			// Read advances to the next row.
			while (reader.Read())
			{
				response += "<div class=\"animal animal-id-"+reader[0]+"\">";
				response += "<h2>" + reader[1] + "</h2>";
				response += "<div><a href='/animals/"+reader[0]+"'>" + reader[5] + "</a></div>";
				response += "<div>Lives in the "+ reader[2] +" ("+ reader[3] +" type) habitat</div>";
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

