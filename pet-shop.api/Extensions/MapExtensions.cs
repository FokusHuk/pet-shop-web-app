using System.Collections;
using System.Collections.Generic;
using System.Linq;
using pet_shop.api.Domain;
using pet_shop.api.Models;

namespace pet_shop.api.Extensions
{
    public static class MapExtensions
    {
        public static IEnumerable<GetPetsResponseItem> Map(this IEnumerable<Pet> pets)
        {
            return pets.Select(pet => new GetPetsResponseItem()
            {
                Id = pet.Id,
                Name = pet.Name,
                Description = pet.Description,
                Price = pet.Price
            });
        }
    }
}