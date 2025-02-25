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
            await Read();
        }
        private async Task Read()
        {
            HttpClient client=new HttpClient();
            HttpResponseMessage response= await client.GetAsync("https://localhost:7160/api/blogs");
            if (response.IsSuccessStatusCode) 
            {
             string json=await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                
             List< BlogDataModel> lst= JsonConvert.DeserializeObject<List<BlogDataModel>>(json)!;
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
    }
}
