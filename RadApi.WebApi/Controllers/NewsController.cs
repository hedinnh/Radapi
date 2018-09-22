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

namespace RadApi.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        // GET api/values
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
                c.Links.AddReference("self", $"api/{c.Id}");
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

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetNewsById(int id)
        {
            var result = new List<NewsItemDetailDto>();
            NewsItemsData.Models.ToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self", $"href:api/{c.Id}");
                    c.Links.AddReference("edit", $"api/{c.Id}");
                    c.Links.AddReference("delete", $"api/{c.Id}");
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
                c.Links.AddReference("self", $"api/categories/{c.Id}");
                c.Links.AddReference("edit", $"api/categories/{c.Id}");
                c.Links.AddReference("delete", $"api/categories/{c.Id}");
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
            //var newsItems = NewsItemsData.Models;
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
                    c.Links.AddReference("self", $"api/categories/{c.Id}");
                    c.Links.AddReference("edit", $"api/categories/{c.Id}");
                    c.Links.AddReference("delete", $"api/categories/{c.Id}");
                    c.Links.AddReference("numberOfNewsItems", $"{count}");
                    c.Links.AddReference("parentCateoryId", $"{c.Id - 1}"); // spurning hvort þetta sé rétt ?
                    temp.Add(c);
                }
            });

            return Ok(temp);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
