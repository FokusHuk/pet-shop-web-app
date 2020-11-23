using System;
using System.Collections.Generic;
using System.Linq;

namespace pet_shop.api.Domain
{
    public class PetsRepository: IPetsRepository
    {
        public PetsRepository()
        {
            var petId = Guid.NewGuid();
            Pets = new Dictionary<Guid, Pet>()
            {
                {petId, new Pet(petId, "Cat", "Nice white pet", 1200)}
            };
        }
        
        public IEnumerable<Pet> GetPets()
        {
            return Pets.Select(petInDict => petInDict.Value);
        }

        private Dictionary<Guid, Pet> Pets;
    }
}