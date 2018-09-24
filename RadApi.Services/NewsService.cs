using System;
using System.Collections;
using System.Collections.Generic;
using RadApi.Models.Dtos;
using RadApi.Models.InputModels;
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
            if (news == null) { throw new Exception($"news with id {id} was not found."); }
            return news;
        }
        public IEnumerable GetAllCategories()
        {
            return _newsRepository.GetAllCategories();
        }
        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = _newsRepository.GetCategoryById(id);
            if (category == null) { throw new Exception($"category with id {id} was not found."); }

            return category;
        }
        public IEnumerable GetAllAuthors()
        {
            return _newsRepository.GetAllAuthors();
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _newsRepository.GetAuthorById(id);
            if (author == null) { throw new Exception($"news with id {id} was not found."); }

            return author;
        }
        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {   
            var news = _newsRepository.GetNewsByAuthorId(id);
            if (news == null) { throw new Exception($"no news with author id {id} was not found."); }

            return news;
        }
        public int CreateNews(NewsItemInputModel newsItemInput)
        {
            return _newsRepository.CreateNews(newsItemInput);
        }
        public void UpdateNewsById(NewsItemInputModel newsItemInput, int id)
        {   
            _newsRepository.UpdateNewsById(newsItemInput, id);
        }
        public void DeleteNewsItemById(int id)
        {
            _newsRepository.DeleteNewsItemById(id);
        }
        public int AddCategory(CategoryInputModel newCategory)
        {
            return _newsRepository.AddCategory(newCategory);
        }
        public void UpdateCategoryById(CategoryInputModel categoryUpdate, int id)
        {
            _newsRepository.UpdateCategoryById(categoryUpdate, id);
        }
        public void DeleteCategoryById(int id)
        {
            _newsRepository.DeleteCategoryById(id);
        }
        public void AssignCategory(int newCategory, int newsId)
        {
            _newsRepository.AssignCategory(newCategory, newsId);
        }
        public int CreateAuthor(AuthorInputModel newAuthor)
        {
            return _newsRepository.CreateAuthor(newAuthor);
        }
        public void UpdateAuthor(AuthorInputModel updateAuthor, int id)
        {
            _newsRepository.UpdateAuthor(updateAuthor, id);
        }
        public void DeleteAuthor(int id)
        {
            _newsRepository.DeleteAuthor(id);
        }
        public void AssignAuthor(int newAuthorId, int newsId)
        {
            _newsRepository.AssignAuthor(newAuthorId, newsId);
        }
    }
}