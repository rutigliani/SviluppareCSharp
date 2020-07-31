using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnessioneAdoNet
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
				cmd.CommandText = "SELECT TOP 5 BusinessEntityID,FirstName,LastName FROM Person.Person";
				cmd.Connection = conn;
				sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Console.WriteLine($"{sdr["BusinessEntityID"]}) {sdr["FirstName"]} {sdr["LastName"]}");
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
