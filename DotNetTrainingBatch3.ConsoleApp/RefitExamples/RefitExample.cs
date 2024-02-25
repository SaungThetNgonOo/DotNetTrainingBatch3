using DotNetTrainingBatch3.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("https://localhost:7194");


        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(5000);
            //await Create("title1","content1","author1");
            await Update(4014,"title2","content2","author2");
            //await Edit(1);
        }
        private async Task Read()
        {
            var lst = await refitApi.GetBlogs();
            foreach (BlogModel item in lst)
            {

                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlog(id);
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);//Main 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task Create(string title,string content,string author)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                string message = await refitApi.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);//Main 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task Update(int id,string title, string content, string author)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                string message = await refitApi.UpdateBlog(id,blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);//Main 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task Delete(int id)
        {
            try
            {
                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);//Main 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
