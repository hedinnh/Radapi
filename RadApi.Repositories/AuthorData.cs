using System.Collections.Generic;
using RadApi.Models.Entities;

namespace RadApi.Repositories
{
    public class AuthorData
    {
               private static List<Author> _models = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "Jenni Penni",
                ProfileImgSource = "https://api.adorable.io/avatars/285/abott@adorable.png",
                Bio = "My name is jenni penni and BTW Jenni is NOT A WOMANS NAME IN ICELAND!!!!!"

            },
            new Author
            {
                Id = 2,
                Name = "Mr jonik",
                ProfileImgSource = "https://api.adorable.io/avatars/285/abott@adowrable.io.png",
                Bio = "My name is john and Love jenni and books!!!!!!!"

            },
            new Author
            {
                Id = 3,
                Name = "Garthar Vader",
                ProfileImgSource = "https://api.adorable.io/avatars/285/aboatt@adowrable.io.png",
                Bio = "My name is gardens and i will water your flower for free wrarrrr"
            }
        };
        public static List<Author> Models { get => _models; set => _models = value; }
    }
}