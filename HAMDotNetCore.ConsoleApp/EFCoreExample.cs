using HAMDotNetCore.ConsoleApp.Models;
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

    }
}
