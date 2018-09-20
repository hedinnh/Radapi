namespace RadApi.Models.InputModels
{
    public class CategoryInputModel
    {
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public string Slug { get; set; }
    }
}