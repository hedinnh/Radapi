namespace RadApi.Models.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Date PublishDate { get; set; }
        public string ModifiedBy { get; set; }
        public Date CreatedDate { get; set; }
        public Date ModifiedDate { get; set; }
    }
}