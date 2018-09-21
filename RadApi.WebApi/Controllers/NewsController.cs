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
 
            NewsItemsData.Models.ToLightWeight().ForEach(c =>
            {
                //c.Links.AddReference("self", $"http://localhost:5000/api/models/{c.Id}");
                temp.Add(c);
                count++;
            });
            
            IEnumerable result = temp.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            envelope.Items = result.Cast<NewsItemDto>();
            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.MaxPages = (int)Math.Ceiling(count/pageSize);
            return Ok(envelope);
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<string> GetNewsById(int id)
        {
            var result = new List<NewsItemDetailDto>();
            NewsItemsData.Models.ToDetails().ForEach(c =>
            {
                if(c.Id == id){
                    //c.Links.AddReference("self",$"http://localhost:5000/api/models/{c.Id}");
                    result.Add(c);
                }
            });
            return Ok(result);
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
