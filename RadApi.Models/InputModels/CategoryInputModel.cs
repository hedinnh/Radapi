using System.ComponentModel.DataAnnotations;

namespace RadApi.Models.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public string Slug { get; set; }
    }
}