using System;
using System.Collections;
using System.Collections.Generic;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;
using RadApi.Repositories;


namespace RadApi.Services
{
    public class NewsService
    {
        private readonly NewsRepository _newsRepository = new NewsRepository();
        public IEnumerable<NewsItemDto> GetAllNews()
        {
            return _newsRepository.GetAllNews();
        }
        public NewsItemDetailDto GetNewsById(int id)
        {
            var news = _newsRepository.GetNewsById(id);
            if(news == null) { throw new Exception($"news with id {id} was not found."); }
            return news;
        }
        public IEnumerable GetAllCategories()
        {
            return _newsRepository.GetAllCategories();
        }
        public CategoryDetailDto GetCategoryById(int id)
        {
            return _newsRepository.GetCategoryById(id);
        }
        public IEnumerable GetAllAuthors()
        {
            return _newsRepository.GetAllAuthors();
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
            return _newsRepository.GetAuthorById(id);
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            return _newsRepository.GetNewsByAuthorId(id);
        }
    }
}