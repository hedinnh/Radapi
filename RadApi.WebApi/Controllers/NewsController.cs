using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;
using RadApi.Repositories;
using RadApi.Services;
using RadApi.Models.Extensions;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using RadApi.Models.InputModels;
using System.Text.RegularExpressions;

namespace RadApi.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private string secretKey = "123";
        private NewsService _newsService = new NewsService();

        [HttpGet]
        public IActionResult GetAllNews(int pageNumber = 1, int pageSize = 25)
        {
            var envelope = new Envelope<NewsItemDto>();
            double count = 0;
            // var result = _newsService.GetAllNews(); // skoda ad nota service seinna !!!
            var temp = new List<NewsItemDto>();
            var sorted = NewsItemsData.Models.OrderBy(p => p.PublishDate).ToList(); // Sort news items by date
            sorted.ToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new {href=$"api/{c.Id}"});
                temp.Add(c);
                count++;
            });

            IEnumerable result = temp.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            envelope.Items = result.Cast<NewsItemDto>();
            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.MaxPages = (int)Math.Ceiling(count / pageSize);
            return Ok(envelope);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetNewsById(int id)
        {
            var result = new List<NewsItemDetailDto>();
            NewsItemsData.Models.ToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self",new {href= $"api/{c.Id}"});
                    c.Links.AddReference("edit", new {href= $"api/{c.Id}"});
                    c.Links.AddReference("delete", new {href= $"api/{c.Id}"});
                    result.Add(c);
                }
            });
            return Ok(result);
        }
        [HttpGet]
        [Route("/api/categories")]
        public IActionResult GetAllCategories()
        {
            var temp = new List<CategoryDto>();
            var categories = CategoryData.Models;
            categories.CategoryToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new {href=$"api/categories/{c.Id}"});
                c.Links.AddReference("edit", new {href=$"api/categories/{c.Id}"});
                c.Links.AddReference("delete", new {href=$"api/categories/{c.Id}"});
                temp.Add(c);
            });

            return Ok(temp);
        }
        [HttpGet]
        [Route("/api/categories/{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
            var temp = new List<CategoryDto>();
            var categories = CategoryData.Models;
            var count = 0;
            foreach (var item in NewsItemsData.Models)
            {
                if (item.CategoryId == id)
                {
                    count++;
                }
            }
            categories.CategoryToLightWeight().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self", new {href= $"api/categories/{c.Id}"});
                    c.Links.AddReference("edit", new {href= $"api/categories/{c.Id}"});
                    c.Links.AddReference("delete", new {href= $"api/categories/{c.Id}"});
                    c.Links.AddReference("numberOfNewsItems", $"{count}");
                    c.Links.AddReference("parentCateoryId", $"{c.Id - 1}"); // spurning hvort þetta sé rétt ?
                    temp.Add(c);
                }
            });
            return Ok(temp);
        }

        [HttpGet]
        [Route("/api/authors/")]
        public IActionResult GetAllAuthors()
        {
            var temp = new List<AuthorDto>();
            var authors = AuthorData.Models;

            authors.AuthorToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new {href= $"api/authors/{c.Id}"});
                c.Links.AddReference("edit", new {href= $"api/authors/{c.Id}"});
                c.Links.AddReference("delete", new {href=$"api/authors/{c.Id}"});
                c.Links.AddReference("newsItems", new {href=$"api/authors/{c.Id}/newsItems"});
                // c.Links.AddReference("newsItemsDetailed", $"api/authors/{c.Id}");
                temp.Add(c);
            }
            );
            return Ok(temp);
        }
        [HttpGet]
        [Route("/api/authors/{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
            var temp = new List<AuthorDetailDto>();
            var authors = AuthorData.Models;

            authors.AuthorToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self", new {href= $"api/authors/{c.Id}"});
                    c.Links.AddReference("edit", new {href=$"api/authors/{c.Id}"});
                    c.Links.AddReference("delete", new {href=$"api/authors/{c.Id}"});
                    c.Links.AddReference("newsItems", new {href=$"api/authors/{c.Id}/newsItems"});
                    // c.Links.AddReference("newsItemsDetailed", $"api/authors/{c.Id}");
                    temp.Add(c);
                }
            }
            );
            return Ok(temp);
        }
        [HttpGet]
        [Route("/api/authors/{id:int}/newsItems")]
        public IActionResult GetNewsByAuthorId(int id)
        {
            var news = NewsItemsData.Models;

            var tempNews = new List<NewsItem>();

            news.ForEach(c =>
            {
                if (c.AuthorId == id)
                {
                    tempNews.Add(c);
                }
            }
            );
            var temp = new List<NewsItemDto>();
            tempNews.ToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new {href=$"api/{c.Id}"});
                c.Links.AddReference("edit", new {href=$"api/{c.Id}"});
                c.Links.AddReference("delete", new {href=$"api/{c.Id}"});
                c.Links.AddReference("authors", new {href=$"api/authors/{id}"});
                // vantar categLories her :D
                temp.Add(c);
            }
            );
            return Ok(temp);
        }
        
        [HttpPost]
        [Route("")]
        public IActionResult CreateNews(NewsItemInputModel newsItemInput)
        {
            string authHeader = Request.Headers["Authorization"];
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var newItem = new NewsItem();
            var nextId = NewsItemsData.Models.Count() + 1;
            newItem.Id = nextId;
            newItem.Title = newsItemInput.Title;
            newItem.AuthorId = newsItemInput.AuthorId;
            newItem.CategoryId = newsItemInput.CategoryId;
            newItem.ImgSource = newsItemInput.ImgSource;
            newItem.ShortDescription = newsItemInput.ShortDescription;
            newItem.LongDescription = newsItemInput.LongDescription;
            newItem.PublishDate = newsItemInput.PublishDate;
            newItem.CreatedDate = DateTime.Now;
            newItem.ModifiedBy = null;
            newItem.ModifiedDate = DateTime.Now;
            NewsItemsData.Models.Add(newItem);

            return Ok();
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateNewsById(NewsItemInputModel newsItemInput, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var updateItem = NewsItemsData.Models.FirstOrDefault(c => c.Id == id);
            if (newsItemInput == null) { return BadRequest(newsItemInput); /* throw something here later*/ }
            updateItem.Title = newsItemInput.Title;
            updateItem.ImgSource = newsItemInput.ImgSource;
            updateItem.ShortDescription = newsItemInput.ShortDescription;
            updateItem.LongDescription = newsItemInput.LongDescription;
            updateItem.ModifiedDate = DateTime.Now;
            updateItem.ModifiedBy = "admin?";
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteNewsItem(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            NewsItemsData.Models.Remove(NewsItemsData.Models.First(note => note.Id == id));
            return Ok();
        }
        [HttpPost]
        [Route("/api/categories/")]
        public IActionResult AddCategory(CategoryInputModel newCategory)
        {
            string authHeader = Request.Headers["Authorization"];
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var tempCategory = new Category();
            var nextId = CategoryData.Models.Count() + 1;
            tempCategory.Id = nextId;
            tempCategory.Name = newCategory.Name;
            // Create slug
            string slug = newCategory.Name.ToLower();
            var test = Regex.Replace(slug, @"\s", "-", RegexOptions.Compiled);
            tempCategory.Slug = test;
            tempCategory.ModifiedBy = "Admin";
            tempCategory.ModifiedDate = DateTime.Now;
            tempCategory.ParentCategoryId = CategoryData.Models.Count();
            CategoryData.Models.Add(tempCategory);
            return Ok();
        }
        // jon, athuga hvort thad se haegt ad bua til fall sem checkar a thessu authHeader og modelstate efst. ljott ad thetta se i hverju einasta falli
        // til ad testa thetta tharf ad senda authentication header med postman sem inniheldur secret key sem er defined efst i thessu skjali.
        [HttpPatch]
        [Route("/api/categories/{id:int}")]
        public IActionResult UpdateCategory(CategoryInputModel categoryUpdate, int id) 
        {
            string authHeader = Request.Headers["Authorization"];
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var updateItem = CategoryData.Models.FirstOrDefault(c => c.Id == id);
            if (categoryUpdate == null) { return BadRequest(categoryUpdate); /* throw something here later*/ }
            updateItem.Name = categoryUpdate.Name;
            updateItem.ModifiedBy = "admin";
            updateItem.ModifiedDate = DateTime.Now;
            // Create slug
            string slug = categoryUpdate.Name.ToLower();
            var test = Regex.Replace(slug, @"\s", "-", RegexOptions.Compiled);
            updateItem.Slug = test;
            return Ok();

        }
    }
}
