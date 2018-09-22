using System;

namespace RadApi.Models.InputModels
{
    public class NewsItemInputModel 
    {
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int AuthorId {get; set;}
        public int CategoryId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}