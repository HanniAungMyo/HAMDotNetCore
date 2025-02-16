using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source =LAPTOP\\SQLSERVER;Initial Catalog =DotNet;User Id =sa;Password =sa@123;";
        public void Read()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Connection :" + _connectionString);
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
        }

        //public void Create()
        //{
        //    Console.WriteLine("Blog Title");
        //    String blogtitle = Console.ReadLine();

        //    Console.WriteLine("Blog Author");
        //    String blogAuthor = Console.ReadLine();

        //    Console.WriteLine("Blog Content");
        //    String blogContent = Console.ReadLine();

        //    Console.WriteLine("Delete Flag");
        //    String DeleteFlag = Console.ReadLine();
        //    SqlConnection connection = new SqlConnection(_connectionString);
        //    Console.WriteLine("Connection Opening");
        //    connection.Open();
        //    //string query2 = $@"INSERT INTO [dbo].[Tbl_Blog] 
        //    //                                   ([BlogTitle]
        //    //                                   ,[BlogAuthor]
        //    //                                   ,[BlogContent]
        //    //                                   ,[DeleteFlag])  
        //    //                                   VALUES
        //    //                                  ('{blogtitle}'
        //    //                                  ,'{blogAuthor}'
        //    //                                  ,'{blogContent}'
        //    //                                  ,0)";
        //    string query = $@"INSERT INTO [dbo].[Tbl_Blog] 
        //                           ([BlogTitle]
        //                           ,[BlogAuthor]
        //                           ,[BlogContent]
        //                           ,[DeleteFlag])  
        //                           VALUES
        //                          (@BlogTitle
        //                          ,@BlogAuthor
        //                          ,@blogContent
        //                          ,0)";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@BlogTitle", blogtitle);
        //    command.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
        //    command.Parameters.AddWithValue("@BlogContent", blogContent);
        //    int result = command.ExecuteNonQuery();
        //    //SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
        //    //DataTable dt2=new DataTable();
        //    //adapter2.Fill(dt2);
        //    connection.Close();
        //    string Status = result > 0 ? "Saving Successfully" : "Save fail";
        //    Console.WriteLine(Status);
        //}

        public void Edit()
        {
            Console.WriteLine(" Blog Id: ");
            string? id = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT 
                 [BlogId]
                ,[BlogTitle]   
                ,[BlogAuthor]
                ,[BlogContent]
                ,[DeleteFlag]
                 FROM [dbo].[Tbl_Blog] where BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];

                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }
            else
            {
                Console.WriteLine("No Data Found");

            }
        }

        public void Delete()
        {
            Console.WriteLine("Blog Id :");
            string BlogId = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", BlogId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();
            connection.Close();
            string status = result > 0 ? "Delete Successful" : "Delete failed";
            Console.WriteLine(status);
        }


        public void Update()
        {
            Console.WriteLine("Blog Id :");
            string BlogId = Console.ReadLine();

            Console.WriteLine("BlogTitle:");
            string BlogTitle = Console.ReadLine();

            Console.WriteLine("BlogAuthor:");
            string BlogAuthor = Console.ReadLine();

            Console.WriteLine("BlogContent:");
            string BlogContent = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] =@BlogAuthor
      ,[BlogContent] =@BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", BlogId);
            command.Parameters.AddWithValue("@BlogTitle", BlogTitle);
            command.Parameters.AddWithValue("@BlogAuthor", BlogAuthor);
            command.Parameters.AddWithValue("@BlogContent", BlogContent);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();
            connection.Close();
            string status = result > 0 ?"Update Successful" : "Update failed";
            Console.WriteLine(status);
        }

    }
}
