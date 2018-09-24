using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;
using RadApi.Models.Extensions;
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
                //c.Links.AddReference("ee",new [] { $"ewrwr{JsonConvert.SerializeObject(obj)}"});
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
                    // c.Links.AddReference("newsItemsDetailed", $"api/authors/{c.Id}");
                    temp.Add(c);
                }
            }
            );
            return Mapper.Map<AuthorDetailDto>(temp.FirstOrDefault(r => r.Id == id));
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
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
            NewsItemsData.Models.ToLightWeight().ForEach(c =>
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
    }
}