
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
string connectionString = "Data Source =LAPTOP\\SQLSERVER;Initial Catalog =DotNet;User Id =sa;Password =sa@123;";
SqlConnection connection = new SqlConnection(connectionString);
Console.WriteLine("Connection :" + connectionString);
Console.WriteLine("Connection Opening");
connection.Open();
string query = @"SELECT 
                 [BlogId]
                ,[BlogTitle]   
                ,[BlogAuthor]
                ,[BlogContent]
                ,[DeleteFlag]
                 FROM [dbo].[Tbl_Blog]";
SqlCommand command = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(command);
//DataTable dt=new DataTable();
//adapter.Fill(dt);
SqlDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine(reader["BlogTitle"]);
    Console.WriteLine(reader["BlogAuthor"]);
    Console.WriteLine(reader["BlogContent"]);
    Console.WriteLine(reader["DeleteFlag"]);
    Console.WriteLine("-----------------------------------------------------------");
}

Console.WriteLine("Connection Opened");
Console.WriteLine("Connection Closing");
connection.Close();
Console.WriteLine("Connection Closed");
//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//    Console.WriteLine(dr["DeleteFlag"]);
//    Console.WriteLine("-----------------------------------------------------------");
//}