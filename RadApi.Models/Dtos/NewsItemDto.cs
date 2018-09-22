using System;
using RadApi.Models.Extensions;

namespace RadApi.Models.Dtos
{
    public class NewsItemDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
    }
}