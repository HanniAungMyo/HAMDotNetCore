using Dapper;
using HAMDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source =LAPTOP\\SQLSERVER;Initial Catalog =DotNet;User Id =sa;Password =sa@123;";
        public void Read()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "Select * from Tbl_blog where DeleteFlag=0";
            var lst = db.Query<BlogDataModel>(query).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Create(String BlogTitle, String BlogAuthor, String BlogContent)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog] 
                                   ([BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent]
                                   ,[DeleteFlag])  
                                   VALUES
                                  (@BlogTitle
                                  ,@BlogAuthor
                                  ,@blogContent
                                  ,0)";
            int result = db.Execute(query, new BlogDataModel
            {
                BlogTitle = BlogTitle,
                BlogAuthor = BlogAuthor,
                BlogContent = BlogContent,
            });
            Console.WriteLine(result > 0 ? "Create Successful" : "Fail");

        }

        public void Edit(int BlogId)
        {
            string query = "Select * from Tbl_Blog where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<BlogDataModel>(query, new BlogDataModel
            {
                BlogId = BlogId
            }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }

            Console.WriteLine(item?.BlogTitle);
            Console.WriteLine(item?.BlogAuthor);
            Console.WriteLine(item?.BlogContent);
        }

        public void Update(int BlogId, String BlogTitle, String BlogAuthor, String BlogContent)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] =@BlogAuthor
      ,[BlogContent] =@BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId=@BlogId";
            BlogDataModel blog = new BlogDataModel()
            {
                BlogId=BlogId,
                BlogTitle=BlogTitle,
                BlogAuthor=BlogAuthor,
                BlogContent=BlogContent,
            };
            IDbConnection db = new SqlConnection(_connectionString);
          int item=  db.Execute(query, blog);
        Console.WriteLine(item>0?"Updating Successful":"Failed Update");
        }

        public void Delete(int id)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                BlogId = id
            };
            string query = "Delete From Tbl_Blog where DeleteFlag=0 and BlogId=@BlogId";
            IDbConnection db=new SqlConnection(_connectionString);
         int result=   db.Execute(query,blog);
            Console.WriteLine(result > 0 ? "Delete Successful" : "Delete failed");
        }
    }
}
