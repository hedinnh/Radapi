using System.Collections.Generic;
using System.Linq;
using RadApi.Models.Dtos;
using RadApi.Models.Entities;

namespace RadApi.Models.Extensions
{
    public static class ListExtensions
    {
        public static List<NewsItemDto> ToLightWeight(this List<NewsItem> list, string language = "en-US") => list.Select(item => new NewsItemDto
        {
            Id = item.Id,
            Title = item.Title,
            ImgSource = item.ImgSource,
            ShortDescription = item.ShortDescription
        }).ToList();
        public static List<NewsItemDetailDto> ToDetails(this List<NewsItem> list, string language = "en-US") => list.Select(item => new NewsItemDetailDto
        {
            Id = item.Id,
            Title = item.Title,
            ImgSource = item.ImgSource,
            ShortDescription = item.ShortDescription,
            LongDescription = item.LongDescription,
            PublishDate = item.PublishDate
            // Rarity = item.Rarity,
            // DifficultyLevel = language == "en-US" ? item.DifficultyLevel : item.DifficultyLevelDE,
            // YearOfRelease = item.YearOfRelease,
            // ImageUrl = item.ImageUrl
        }).ToList();
        public static List<CategoryDto> CategoryToLightWeight(this List<Category> list, string language = "en-US") => list.Select(item => new CategoryDto
        {
            Id = item.Id,
            Name = item.Name,
            Slug = item.Slug
        }).ToList();
    }
}