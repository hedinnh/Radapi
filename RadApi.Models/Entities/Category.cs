using System;

namespace RadApi.Models.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ParentCategoryId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}