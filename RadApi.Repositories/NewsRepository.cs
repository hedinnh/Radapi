using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;
using RadApi.Models.Extensions;
using RadApi.Models.InputModels;
using RadApi.Repositories.Data;

namespace RadApi.Repositories
{
    public class NewsRepository
    {

        public IEnumerable<NewsItemDto> GetAllNews()
        {
            var temp = new List<NewsItemDto>();
            var sorted = NewsItemsData.Models.OrderBy(p => p.PublishDate).ToList();
            sorted.ToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new { href = $"api/{c.Id}" });
                c.Links.AddReference("edit", new { href = $"api/{c.Id}" });
                c.Links.AddReference("delete", new { href = $"api/{c.Id}" });
                c.Links.AddReference("authors", new[] { new { href = $"api/authors/{c.Id}" } });
                c.Links.AddReference("categories", new[] { new { href = $"api/categories/{c.Id}" } });
                temp.Add(c);
            });
            return (temp);
        }
        public NewsItemDetailDto GetNewsById(int id)
        {
            var result = new List<NewsItemDetailDto>();
            NewsItemsData.Models.ToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self", new { href = $"api/{c.Id}" });
                    c.Links.AddReference("edit", new { href = $"api/{c.Id}" });
                    c.Links.AddReference("delete", new { href = $"api/{c.Id}" });
                    c.Links.AddReference("authors", new[] { new { href = $"api/authors/{c.Id}" } });
                    c.Links.AddReference("categories", new[] { new { href = $"api/categories/{c.Id}" } });
                    result.Add(c);
                }
            });
            return Mapper.Map<NewsItemDetailDto>(result.FirstOrDefault(r => r.Id == id));
        }
        public IEnumerable GetAllCategories()
        {
            var temp = new List<CategoryDto>();
            CategoryData.Models.CategoryToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new { href = $"api/categories/{c.Id}" });
                c.Links.AddReference("edit", new { href = $"api/categories/{c.Id}" });
                c.Links.AddReference("delete", new { href = $"api/categories/{c.Id}" });
                temp.Add(c);
            });
            return temp;
        }
        public CategoryDetailDto GetCategoryById(int id)
        {
            var temp = new List<CategoryDetailDto>();
            var count = 0;
            foreach (var item in NewsItemsData.Models)
            {
                if (item.CategoryId == id)
                {
                    count++;
                }
            }
            CategoryData.Models.CategoryToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("numberOfNewsItems", $"{count}");
                    c.Links.AddReference("parentCateoryId", $"{c.Id - 1}");
                    c.Links.AddReference("self", new { href = $"api/categories/{c.Id}" });
                    c.Links.AddReference("edit", new { href = $"api/categories/{c.Id}" });
                    c.Links.AddReference("delete", new { href = $"api/categories/{c.Id}" });
                    temp.Add(c);
                }
            });
            return Mapper.Map<CategoryDetailDto>(temp.FirstOrDefault(r => r.Id == id));
        }
        public IEnumerable GetAllAuthors()
        {
            var temp = new List<AuthorDto>();
            AuthorData.Models.AuthorToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new { href = $"api/authors/{c.Id}" });
                c.Links.AddReference("edit", new { href = $"api/authors/{c.Id}" });
                c.Links.AddReference("delete", new { href = $"api/authors/{c.Id}" });
                c.Links.AddReference("newsItems", new { href = $"api/authors/{c.Id}/newsItems" });
                temp.Add(c);
            }
            );
            return temp;
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
            var temp = new List<AuthorDetailDto>();
            AuthorData.Models.AuthorToDetails().ForEach(c =>
            {
                if (c.Id == id)
                {
                    c.Links.AddReference("self", new { href = $"api/authors/{c.Id}" });
                    c.Links.AddReference("edit", new { href = $"api/authors/{c.Id}" });
                    c.Links.AddReference("delete", new { href = $"api/authors/{c.Id}" });
                    c.Links.AddReference("newsItems", new { href = $"api/authors/{c.Id}/newsItems" });
                    temp.Add(c);
                }
            }
            );
            return Mapper.Map<AuthorDetailDto>(temp.FirstOrDefault(r => r.Id == id));
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            var tempNews = new List<NewsItem>();
            NewsItemsData.Models.ForEach(c =>
            {
                if (c.AuthorId == id) { tempNews.Add(c); }
            }
            );
            tempNews.Cast<NewsItemDto>();
            var temp = new List<NewsItemDto>();
            tempNews.ToLightWeight().ForEach(c =>
            {
                c.Links.AddReference("self", new { href = $"api/{c.Id}" });
                c.Links.AddReference("edit", new { href = $"api/{c.Id}" });
                c.Links.AddReference("delete", new { href = $"api/{c.Id}" });
                c.Links.AddReference("authors", new { href = $"api/authors/{id}" });
                temp.Add(c);
            }
            );
            return temp;
        }
        public int CreateNews(NewsItemInputModel newsItemInput)
        {
            var newItem = new NewsItem();
            var nextId = NewsItemsData.Models.Count() + 1;
            newItem.Id = nextId;
            newItem.Title = newsItemInput.Title;
            newItem.ImgSource = newsItemInput.ImgSource;
            newItem.ShortDescription = newsItemInput.ShortDescription;
            newItem.LongDescription = newsItemInput.LongDescription;
            newItem.PublishDate = newsItemInput.PublishDate;
            newItem.CreatedDate = DateTime.Now;
            newItem.ModifiedBy = null;
            newItem.ModifiedDate = DateTime.Now;
            NewsItemsData.Models.Add(newItem);
            return nextId;
        }

        public void UpdateNewsById(NewsItemInputModel newsItemInput, int id)
        {

            var updateItem = NewsItemsData.Models.FirstOrDefault(c => c.Id == id);
            if (updateItem == null) { return; throw new Exception($"Can not be null"); }
            updateItem.Title = newsItemInput.Title;
            updateItem.ImgSource = newsItemInput.ImgSource;
            updateItem.ShortDescription = newsItemInput.ShortDescription;
            updateItem.LongDescription = newsItemInput.LongDescription;
            updateItem.ModifiedDate = DateTime.Now;
            updateItem.ModifiedBy = "admin";
        }
        public void DeleteNewsItemById(int id)
        {
            NewsItemsData.Models.Remove(NewsItemsData.Models.First(n => n.Id == id));
        }
        public int AddCategory(CategoryInputModel newCategory)
        {
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
            return nextId;
        }
        public void UpdateCategoryById(CategoryInputModel categoryUpdate, int id)
        {
            var updateItem = CategoryData.Models.FirstOrDefault(c => c.Id == id);
            if (updateItem == null) { return; throw new Exception($"Can not be null"); }

            updateItem.Name = categoryUpdate.Name;
            updateItem.ModifiedBy = "admin";
            updateItem.ModifiedDate = DateTime.Now;
            // Create slug
            string slug = categoryUpdate.Name.ToLower();
            var test = Regex.Replace(slug, @"\s", "-", RegexOptions.Compiled);
            updateItem.Slug = test;
        }
        public void DeleteCategoryById(int id)
        {
            CategoryData.Models.Remove(CategoryData.Models.First(note => note.Id == id));
        }
        public void AssignCategory(int newCategory, int newsId)
        {
            var newsToChange = NewsItemsData.Models.First(c => c.Id == newsId);
            if (newsToChange == null) { return; throw new Exception($"Can not be null"); }

            newsToChange.CategoryId = newCategory;
        }
        public int CreateAuthor(AuthorInputModel newAuthor)
        {
            var authorToAdd = new Author();
            var nextId = AuthorData.Models.Count() + 1;
            authorToAdd.Id = nextId;
            authorToAdd.Name = newAuthor.Name;
            authorToAdd.ProfileImgSource = newAuthor.ProfileImgSource;
            authorToAdd.Bio = newAuthor.Bio;
            AuthorData.Models.Add(authorToAdd);
            return nextId;
        }
        public void UpdateAuthor(AuthorInputModel updateAuthor, int id)
        {
            var authorToUpdate = AuthorData.Models.First(c => c.Id == id);
            if (authorToUpdate == null) { return; throw new Exception($"Can not be null"); }

            authorToUpdate.Name = updateAuthor.Name;
            authorToUpdate.ProfileImgSource = updateAuthor.ProfileImgSource;
            authorToUpdate.Bio = updateAuthor.Bio;
        }
        public void DeleteAuthor(int id)
        {
            AuthorData.Models.Remove(AuthorData.Models.First(n => n.Id == id));
        }
        public void AssignAuthor(int newAuthorId, int newsId)
        {
            var newsToChange = NewsItemsData.Models.First(c => c.Id == newsId);
            if (newsToChange == null) { return; throw new Exception($"Can not be null"); }

            newsToChange.AuthorId = newAuthorId;
        }
    }
}