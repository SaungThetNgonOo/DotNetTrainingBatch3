using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample2
    {
        public async Task Run()
        {
            //await Read();
            await ReadJsonPlaceHolder();
        }
        //https://jsonplaceholder.typicode.com/
        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response= await client.GetAsync("https://localhost:7194/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr=await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                //JsonConvert.SerializeObject();//C# object to Json
                //JsonConvert.DeserializeObject();//Json to C# object
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (BlogModel item in lst)
                {

                    Console.WriteLine(item.BlogID);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        private async Task ReadJsonPlaceHolder()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                //JsonConvert.SerializeObject();//C# object to Json
                //JsonConvert.DeserializeObject();//Json to C# object
                List<JsonPlaceHolderModel> lst = JsonConvert.DeserializeObject<List<JsonPlaceHolderModel>>(jsonStr)!;
                
                foreach (JsonPlaceHolderModel item in lst)
                {
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                }
            }
        }
    }
}
