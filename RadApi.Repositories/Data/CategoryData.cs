using System.Collections.Generic;
using RadApi.Models.Entities;

namespace RadApi.Repositories.Data
{
    public class CategoryData
    {
        private static List<Category> _models = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "International News",
                Slug = "international-news"
            },
            new Category
            {
                Id = 2,
                Name = "Domestic",
                Slug = "domestic"
            },
            new Category
            {
                Id = 3,
                Name = "Weather",
                Slug = "weather"
            }
        };
        public static List<Category> Models { get => _models; set => _models = value; }
    }
}