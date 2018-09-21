using System.Collections.Generic;
using RadApi.Models.Entities;
using RadApi.Repositories;


namespace RadApi.Services
{
    public class NewsService
    {
        private readonly NewsItemsData _newsService = new NewsItemsData();
        public IEnumerable<NewsItem> GetAllNews()
        {
            return NewsItemsData.Models;
        }

    }
}