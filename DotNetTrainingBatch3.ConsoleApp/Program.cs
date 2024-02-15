// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Start
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "TestDb";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa@123";

//string query = @"SELECT [BlogID]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//  FROM [dbo].[Tbl_Blog]";
//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//sqlConnection.Open();

//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//DataTable dt = new DataTable();
//adapter.Fill(dt);

//sqlConnection.Close();

////dataset
////datatable

//foreach (DataRow dr in dt.Rows)
//{

//    Console.WriteLine(dr["BlogID"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//}