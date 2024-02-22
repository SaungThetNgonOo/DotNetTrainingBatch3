using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {

        private readonly string _apiurl = "https://localhost:7194/api/Blog";
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
            RestRequest request = new RestRequest(_apiurl, Method.Get);
            RestClient client= new RestClient();
            RestResponse response= await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(json)!;
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
                Console.WriteLine( response.Content!);
            }
        }

        public async Task Edit(int id)
        {
            string url = $"{_apiurl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json =  response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine( response.Content);
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest request = new RestRequest(_apiurl, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            
            string url = $"{_apiurl}/{id}";
            RestRequest request = new RestRequest(url, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
        private async Task Delete(int id)
        {
            string url = $"{_apiurl} /{id}";
            RestRequest request = new RestRequest(url, Method.Post);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }
}
