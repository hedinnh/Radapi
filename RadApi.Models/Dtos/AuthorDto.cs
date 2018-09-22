using RadApi.Models.Extensions;

namespace RadApi.Models.Dtos
{
    public class AuthorDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}