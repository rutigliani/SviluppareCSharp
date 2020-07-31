using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipolazioneDati
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
				//cmd.Connection = conn;

				/*
				#region inserimento
				var insertCommand = new SqlCommand("INSERT INTO [Production].[Location] " +
												   "([Name] " +
												    ",[CostRate] " +
													",[Availability] " +
													",[ModifiedDate]) " +
													" VALUES (@Name " +
													",@CostRate " +
													",@Availability " +
													",@ModifiedDate)");

				insertCommand.Parameters.Add("@Name",SqlDbType.NVarChar,50);
				insertCommand.Parameters.Add("@CostRate", SqlDbType.SmallMoney);
				insertCommand.Parameters.Add("@Availability", SqlDbType.Decimal);
				insertCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime);

				insertCommand.Parameters["@Name"].Value = "Magazzino principalee";
				insertCommand.Parameters["@CostRate"].Value = 12.23;
				insertCommand.Parameters["@Availability"].Value = 1500.34;
				insertCommand.Parameters["@ModifiedDate"].Value = DateTime.Now;
				insertCommand.Connection = conn;
				insertCommand.ExecuteNonQuery();
				#endregion

				#region aggiornamento
				var updateCommand = new SqlCommand("UPDATE [Production].[Location] " +
												   " SET Name = @Name " +
												   " ,[CostRate] = @CostRate " +
												   " ,[ModifiedDate] = @ModifiedDate " +
												   " WHERE LocationId = @LocationId");
				updateCommand.Parameters.Add("@CostRate", SqlDbType.SmallInt);
				updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
				updateCommand.Parameters.Add("@CostRate", SqlDbType.SmallMoney);
				updateCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime);

				updateCommand.Parameters["@LocationId"].Value = 61;
				updateCommand.Parameters[1].Value = "magazzino secondario";
				updateCommand.Parameters["@CostRate"].Value = 123.54;
				updateCommand.Parameters[3].Value = DateTime.Now;
				updateCommand.Connection = conn;
				updateCommand.ExecuteNonQuery();
				#endregion
				*/
				#region eliminazione
				var deleteCommand = new SqlCommand("DELETE FROM [Production].[Location] " +
												   "WHERE LocationId = @LocationId");
				deleteCommand.Parameters.Add("@LocationId", SqlDbType.SmallInt);
				deleteCommand.Parameters["@LocationId"].Value = 66;
				deleteCommand.Connection = conn;
				deleteCommand.ExecuteNonQuery();

				#endregion

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
