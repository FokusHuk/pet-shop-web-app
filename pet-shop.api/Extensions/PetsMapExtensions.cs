using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using pet_shop.api.Domain;
using pet_shop.api.Models;

namespace pet_shop.api.Extensions
{
    public static class PetsMapExtensions
    {
        public static PetDto Map(this GeneralPetRequest petRequest)
        {
            return new PetDto(
                petRequest.Name, 
                petRequest.Description, 
                petRequest.Price);
        }

        public static DeletePetResponse Map(this PetDto petDto)
        {
            return new DeletePetResponse()
            {
                Name = petDto.Name,
                Description = petDto.Description,
                Price = petDto.Price
            };
        }
    }
}