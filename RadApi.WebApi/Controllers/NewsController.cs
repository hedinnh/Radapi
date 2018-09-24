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
using System.Dynamic;
using Newtonsoft.Json;

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
        [Route("{id:int}")]
        public IActionResult GetNewsById(int id)
        {
            return Ok(_newsService.GetNewsById(id));
        }
        [HttpGet]
        [Route("/api/categories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_newsService.GetAllCategories());
        }
        [HttpGet]
        [Route("/api/categories/{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_newsService.GetCategoryById(id));
        }

        [HttpGet]
        [Route("/api/authors/")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_newsService.GetAllAuthors());
        }
        [HttpGet]
        [Route("/api/authors/{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_newsService.GetAuthorById(id));
        }
        [HttpGet]
        [Route("/api/authors/{id:int}/newsItems")]
        public IActionResult GetNewsByAuthorId(int id)
        {
            return Ok(_newsService.GetNewsByAuthorId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNews(NewsItemInputModel newsItemInput)
        {
            string authHeader = Request.Headers["Authorization"];
            if (!ModelState.IsValid)
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
        public IActionResult DeleteNewsItemById(int id)
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
            if (!ModelState.IsValid)
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
            tempCategory.ParentCategoryId = CategoryData.Models.Count(); // ath piazza
            CategoryData.Models.Add(tempCategory);
            return Ok();
        }

        [HttpPatch]
        [Route("/api/categories/{id:int}")]
        public IActionResult UpdateCategory(CategoryInputModel categoryUpdate, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var updateItem = CategoryData.Models.FirstOrDefault(c => c.Id == id);
            if (categoryUpdate == null) { return BadRequest(categoryUpdate); }
            updateItem.Name = categoryUpdate.Name;
            updateItem.ModifiedBy = "admin";
            updateItem.ModifiedDate = DateTime.Now;
            // Create slug
            string slug = categoryUpdate.Name.ToLower();
            var test = Regex.Replace(slug, @"\s", "-", RegexOptions.Compiled);
            updateItem.Slug = test;
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [Route("/api/categories/{id:int}")]
        public IActionResult DeleteCategoryById(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            CategoryData.Models.Remove(CategoryData.Models.First(note => note.Id == id));
            return Ok();
        }

        [HttpPatch]
        [Route("/api/categories/newsItems/")]
        public IActionResult ChangeCategory(int newCategory, int NewsId)
        {
            // This part is a bit strange. If you add a new newsitem it has no category at first.
            // so how can you go to /api/categories/{categoryId}/newsItems/{newsItemId} when {categoryId} does not yet exist for the newsitem you are trying to access?
            // We implemented this so that you go to /api/categories/newsItems and send in queryparameters for the news item and the category you want to link
            // Same goes for the authorid (last function in this file)
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var newsToChange = NewsItemsData.Models.First(c => c.Id == NewsId);
            newsToChange.CategoryId = NewsId;
            return Ok();
        }
        [HttpPost]
        [Route("/api/authors/")]
        public IActionResult CreateAuthor(AuthorInputModel newAuthor)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var authorToAdd = new Author();

            authorToAdd.Id = AuthorData.Models.Count() + 1;
            authorToAdd.Name = newAuthor.Name;
            authorToAdd.ProfileImgSource = newAuthor.ProfileImgSource;
            authorToAdd.Bio = newAuthor.Bio;

            AuthorData.Models.Add(authorToAdd);
            return Ok();
        }
        [HttpPatch]
        [Route("/api/authors/{id:int}/")]
        public IActionResult UpdateAuthor(AuthorInputModel updateAuthor, int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var authorToUpdate = AuthorData.Models.First(c => c.Id == id);
            authorToUpdate.Name = updateAuthor.Name;
            authorToUpdate.ProfileImgSource = updateAuthor.ProfileImgSource;
            authorToUpdate.Bio = updateAuthor.Bio;

            return Ok();
        }
        [HttpDelete]
        [Route("/api/authors/{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            AuthorData.Models.Remove(AuthorData.Models.First(note => note.Id == id));
            return Ok();
        }
        [HttpPatch]
        [Route("/api/categories/newsItems/")]
        public IActionResult ChangeAuthor(int newAuthorId, int NewsId)
        {
            string authHeader = Request.Headers["Authorization"];
            if (secretKey != authHeader)
            {
                return Unauthorized();
            };
            var NewsToChange = NewsItemsData.Models.First(c => c.Id == NewsId);
            NewsToChange.AuthorId = newAuthorId;
            return Ok();
        }
    }
}
