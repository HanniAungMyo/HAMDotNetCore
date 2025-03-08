using HAMDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.ConsoleApp.HTTPClientExample
{
    public class HttpClientExample1
    {
        public async Task Run()
        {
            await Edit(1);
        }
        public async Task Read()
        {
            HttpClient client=new HttpClient();
         HttpResponseMessage Response= await  client.GetAsync("https://localhost:7160/api/Blogs");
            if (Response.IsSuccessStatusCode)
            {
             String json =  await Response.Content.ReadAsStringAsync();
            List<BlogDataModel> lst=    JsonConvert.DeserializeObject<List<BlogDataModel>>(json);
                foreach (BlogDataModel item in lst)
                { 
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                    Console.WriteLine(item.DeleteFlag);
                }

            }

            else
            {
                Console.WriteLine(Response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            string url = $"https://localhost:7160/api/Blogs/{id}";
            HttpClient client =new HttpClient();
          HttpResponseMessage Response =  await client.GetAsync(url);
            if (Response.IsSuccessStatusCode)
            { 
             string json=  await Response.Content.ReadAsStringAsync();
            BlogDataModel item=    JsonConvert.DeserializeObject<BlogDataModel>(json);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);
            }
            else
            {
                Console.Write(await Response.Content.ReadAsStringAsync());
            }
        }
    }
}
