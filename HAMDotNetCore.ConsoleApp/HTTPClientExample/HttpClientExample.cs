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
        public async Task Run()
        {
            await Edit(7);
        }
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7160/api/blogs");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                List<BlogDataModel> lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(json)!;
                foreach (BlogDataModel model in lst)
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


        private async Task Edit(int id)
        {
            string url = $"https://localhost:7160/api/blogs/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                // List<JsonPlaceholder> lst = JsonConvert.DeserializeObject<List<JsonPlaceholder>>(json)!;

                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(json)!;
              
                {  
                
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                    Console.WriteLine(item.DeleteFlag);
                    Console.WriteLine("-------------------------------------------------------------------");
                }
               
            }

            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }


        }


    }
}
