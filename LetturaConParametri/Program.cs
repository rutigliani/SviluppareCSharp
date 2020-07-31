using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetturaConParametri
{
	class Program
	{
		static void Main(string[] args)
		{
			SqlConnection conn = new SqlConnection(CommonInfo.Common.GetConnectionString());
			SqlCommand cmd = new SqlCommand();
			SqlDataReader sdr;

			try
			{
				conn.Open();
				Console.WriteLine($"connessione al db {conn.Database} effettuata!!!");

				//operazioni che devo fare C.R.U.D.
				//cmd.CommandText = "SELECT TOP 5 BusinessEntityID,FirstName,LastName FROM Person.Person";
				cmd.Connection = conn;
				var LastNameFilter = "D%";
				var modifiedDateFilter = new DateTime(2003, 1, 1);
				Console.WriteLine("indica il filtro sul cognome di tipo \"like\":");
				var filterByUser = Console.ReadLine();


				#region query seria
				cmd.CommandText = "SELECT TOP 5 BusinessEntityID,FirstName,LastName,ModifiedDate " +
								  "FROM Person.Person " +
								  "WHERE LastName LIKE @LastNameFilter " +
								  "AND ModifiedDate > @DateFilter";
				cmd.Parameters.Add("@LastNameFilter", System.Data.SqlDbType.NVarChar, 50);
				cmd.Parameters.Add("@DateFilter", System.Data.SqlDbType.DateTime);

				cmd.Parameters["@LastNameFilter"].Value = $"{filterByUser}%";
				cmd.Parameters["@DateFilter"].Value = modifiedDateFilter;


				#endregion


				sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Console.WriteLine($"{sdr["BusinessEntityID"]}) {sdr["FirstName"]} {sdr["LastName"]} {sdr[3]:dd/MM/yyyy}");
				}
				sdr.Close();
				conn.Close();
				Console.WriteLine($"disconnesso");

			}
			catch (Exception ex)
			{
				if (conn.State == System.Data.ConnectionState.Open)
					conn.Close();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}
			Console.WriteLine($"premi un tasto per continuare...");
			Console.ReadLine();
		}
	}
}
