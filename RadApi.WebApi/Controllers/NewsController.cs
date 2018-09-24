using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;
using RadApi.Services;
using RadApi.Models.InputModels;
using RadApi.Repositories;

namespace RadApi.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private string secretKey = "123";
        private readonly NewsService _newsService = new NewsService();

        [HttpGet]
        public IActionResult GetAllNews(int pageNumber = 1, int pageSize = 25)
        {
            var envelope = new Envelope<NewsItemDto>();
            var news = _newsService.GetAllNews();
            double count = news.Count();
            IEnumerable result = news.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            envelope.Items = result.Cast<NewsItemDto>();
            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.MaxPages = (int)Math.Ceiling(count / pageSize);
            return Ok(envelope);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetNewsItemById")]
        public IActionResult GetNewsById(int id)
        {
            if (!NewsItemsData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} not found"); }
            return Ok(_newsService.GetNewsById(id));
        }
        [HttpGet]
        [Route("/api/categories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_newsService.GetAllCategories());
        }
        [HttpGet]
        [Route("/api/categories/{id:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            if (!CategoryData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} not found"); }

            return Ok(_newsService.GetCategoryById(id));
        }

        [HttpGet]
        [Route("/api/authors/")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_newsService.GetAllAuthors());
        }
        [HttpGet]
        [Route("/api/authors/{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            if (!AuthorData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} not found"); }

            return Ok(_newsService.GetAuthorById(id));
        }
        [HttpGet]
        [Route("/api/authors/{id:int}/newsItems")]
        public IActionResult GetNewsByAuthorId(int id)
        {
            if (_newsService.GetNewsByAuthorId(id).Count() == 0) { return StatusCode(404, $"id: {id} has no news"); };
            return Ok(_newsService.GetNewsByAuthorId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNews([FromBody] NewsItemInputModel newsItemInput)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!ModelState.IsValid) { return StatusCode(412, newsItemInput); }

            var id = _newsService.CreateNews(newsItemInput);
            return CreatedAtRoute("GetNewsItemById", new { id }, null);
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateNewsById(NewsItemInputModel newsItemInput, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!ModelState.IsValid) { return StatusCode(412, newsItemInput); }
            if (!NewsItemsData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} not found"); }

            _newsService.UpdateNewsById(newsItemInput, id);
            return NoContent();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteNewsItemById(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!NewsItemsData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} not found"); }

            _newsService.DeleteNewsItemById(id);
            return NoContent();
        }
        [HttpPost]
        [Route("/api/categories/")]
        public IActionResult AddCategory([FromBody] CategoryInputModel newCategory)
        {
            string authHeader = Request.Headers["Authorization"];
            if (!ModelState.IsValid) { return StatusCode(412, newCategory); }
            if (secretKey != authHeader) { return Unauthorized(); };

            var id = _newsService.AddCategory(newCategory);
            return CreatedAtRoute("GetCategoryById", new { id }, null);
        }

        [HttpPatch]
        [Route("/api/categories/{id:int}")]
        public IActionResult UpdateCategoryById(CategoryInputModel categoryUpdate, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (!ModelState.IsValid) { return StatusCode(412, categoryUpdate); }
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!CategoryData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} category not found"); }

            _newsService.UpdateCategoryById(categoryUpdate, id);
            return NoContent();
        }
        [HttpDelete]
        [Route("/api/categories/{id:int}")]
        public IActionResult DeleteCategoryById(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!CategoryData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} category not found"); }

            _newsService.DeleteCategoryById(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("/api/categories/newsItems/")]
        public IActionResult AssignCategory(int newCategory, int newsId)
        {
            // This part is a bit strange. If you add a new newsitem it has no category at first.
            // so how can you go to /api/categories/{categoryId}/newsItems/{newsItemId} when {categoryId} does not yet exist for the newsitem you are trying to access?
            // We implemented this so that you go to /api/categories/newsItems and send in queryparameters for the news item and the category you want to link
            // Same goes for the authorId (last function in this file)
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!CategoryData.Models.Any(n => n.Id == newCategory)) { return StatusCode(404, $"id: {newCategory} can not add to a non existing category, please create it first"); }

            _newsService.AssignCategory(newCategory, newsId);
            return NoContent();
        }
        [HttpPost]
        [Route("/api/authors/")]
        public IActionResult CreateAuthor(AuthorInputModel newAuthor)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!ModelState.IsValid) { return StatusCode(412, newAuthor); }

            var id = _newsService.CreateAuthor(newAuthor);
            return CreatedAtRoute("GetAuthorById", new { id }, null);
        }
        [HttpPatch]
        [Route("/api/authors/{id:int}/")]
        public IActionResult UpdateAuthor(AuthorInputModel updateAuthor, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!ModelState.IsValid) { return StatusCode(412, updateAuthor); }
            if (!AuthorData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} Author does not exist, please create it first"); }

            _newsService.UpdateAuthor(updateAuthor, id);
            return NoContent();
        }
        [HttpDelete]
        [Route("/api/authors/{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!AuthorData.Models.Any(n => n.Id == id)) { return StatusCode(404, $"id: {id} id not found"); }

            _newsService.DeleteAuthor(id);
            return NoContent();
        }
        [HttpPatch]
        [Route("/api/authors/newsItems/")]
        public IActionResult AssignAuthor(int newAuthorId, int newsId)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader) { return Unauthorized(); };
            if (!AuthorData.Models.Any(n => n.Id == newAuthorId)) { return StatusCode(404, $"id: {newAuthorId} Author does not exist, please create it first"); }

            _newsService.AssignAuthor(newAuthorId, newsId);
            return NoContent();
        }
    }
}
