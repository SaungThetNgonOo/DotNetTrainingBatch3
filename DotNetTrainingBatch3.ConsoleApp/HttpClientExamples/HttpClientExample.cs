using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(100);
            //await Create("title1", "author1", "content1");
            //await Update(3016, "title2", "author2", "content2");
            //await Delete(3016);
        }
        private async Task Read()
        {
            HttpClient client=new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7194/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string json=await response.Content.ReadAsStringAsync();
                List<BlogModel> lst=JsonConvert.DeserializeObject<List<BlogModel>>(json)!;
                foreach (BlogModel item in lst)
                {

                    Console.WriteLine(item.BlogID);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            string url = $"https://localhost:7194/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle=title,
                BlogAuthor=author,
                BlogContent=content
            };
            string jsonBlog=JsonConvert.SerializeObject(blog);
            HttpContent httpcontent = new StringContent(jsonBlog,Encoding.UTF8,MediaTypeNames.Application.Json);
            string url = $"https://localhost:7194/api/Blog";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url,httpcontent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task Update(int id,string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpcontent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7194/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, httpcontent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task Delete(int id)
        {
            string url = $"https://localhost:7194/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
