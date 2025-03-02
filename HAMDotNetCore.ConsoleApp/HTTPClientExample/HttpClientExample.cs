using HAMDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.ConsoleApp.HTTPClientExample
{
    public class HttpClientExample
    {
        public async Task
             Run()
        {
            await ReadPlaceHolder();
        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7160/api/blogs");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                List<JsonPlaceholder> lst = JsonConvert.DeserializeObject<List<JsonPlaceholder>>(json)!;
                foreach (JsonPlaceholder model in lst)
                {
                    Console.WriteLine(model.BlogTitle);
                    Console.WriteLine(model.BlogAuthor);
                    Console.WriteLine(model.BlogContent);
                    Console.WriteLine(model.DeleteFlag);
                    Console.WriteLine("-------------------------------------------------------------------");
                }
            }




        }


        private async Task ReadPlaceHolder()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                List<Rootobject> lst = JsonConvert.DeserializeObject<List<Rootobject>>(json)!;
                foreach (Rootobject item in lst)
                {
                    //Console.WriteLine(item.Title);
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }
    }
}
