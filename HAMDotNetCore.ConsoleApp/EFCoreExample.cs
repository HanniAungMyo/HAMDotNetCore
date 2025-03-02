using HAMDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
           // var lst = db.Blog.Where(x => x.DeleteFlag == false).ToList();
           var lst=db.Blog.Where(x=>x.DeleteFlag==false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);
                Console.WriteLine("-------------------------------");
            }
        }
        public void Create(string title,string author,string content)
        {
            JsonPlaceholder model = new JsonPlaceholder()
            {
               BlogTitle = title,
               BlogAuthor = author,
               BlogContent = content,
            };
            AppDbContext db=new AppDbContext();
            db.Blog.Add(model);
            var result = db.SaveChanges();
            Console.WriteLine(result>0?"Create Successful":"Create Fail");
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var item= db.Blog.FirstOrDefault(x=>x.BlogId==id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Update(int id, string title, string author, string content) 
        {
           
            AppDbContext db = new AppDbContext();
              var item=  db.Blog.AsNoTracking().FirstOrDefault(x=>x.BlogId==id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }
             if (!string.IsNullOrEmpty(author))
            {
              item.BlogAuthor=author;
            }
             if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent=content;
            }

            db.Entry(item).State=EntityState.Modified;
            int result = db.SaveChanges();

            Console.WriteLine(result > 0 ? "Updating Successful" : "Updating Fail");
           
        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blog.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.Entry(item).State = EntityState.Deleted;
            int result = db.SaveChanges();

            Console.WriteLine(result > 0 ? "Delete Successful" : "Delete Fail");
        }


    }
}
