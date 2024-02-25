// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainingBatch3.ConsoleApp.HttpClientExamples;
using DotNetTrainingBatch3.ConsoleApp.Models;
using DotNetTrainingBatch3.ConsoleApp.RefitExamples;
using DotNetTrainingBatch3.ConsoleApp.RestClientExamples;
using Newtonsoft.Json;
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

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(5);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Create("test title", "test author", "test content");
//adoDotNetExample.Update(1014,"test title8", "test author8", "test content8");
//adoDotNetExample.Delete(1015);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(2);
//dapperExample.Create("test title5","test author5","test content5");
//dapperExample.Update(1016, "test title9", "test author9", "test content9");
//dapperExample.Delete(1016);

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(6);
//eFCoreExample.Create("test title2", "test author2", "test content2");
//eFCoreExample.Update(1017, "test title9", "test author9", "test content9");
//eFCoreExample.Delete(1017);

//Console.WriteLine("Waiting for api...");
//Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//BlogModel blog = new BlogModel();
//blog.BlogTitle = "Test";
//blog.BlogAuthor = "Test";
//blog.BlogContent = "Test";

//string json=JsonConvert.SerializeObject(blog);//C# object to json
//Console.WriteLine(blog);
//Console.WriteLine(json);
//Console.WriteLine(blog.BlogTitle);
//Console.WriteLine(blog.BlogAuthor);
//Console.WriteLine(blog.BlogContent);

//BlogModel blog2= JsonConvert.DeserializeObject<BlogModel>(json)!;
//Console.WriteLine(blog2.BlogTitle);
//Console.WriteLine(blog2.BlogAuthor);
//Console.WriteLine(blog2.BlogContent);

Console.WriteLine("Waiting for api...");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample=new RestClientExample();
//await restClientExample.Run();

RefitExample refitClientExample = new RefitExample();
await refitClientExample.Run();

Console.ReadKey();

