using System;
using System.Collections.Generic;
using System.Linq;

namespace pet_shop.api.Domain
{
    public class PetsRepository: IPetsRepository
    {
        public IEnumerable<Pet> GetPets()
        {
            return _pets.Select(petInDict => petInDict.Value);
        }

        public Pet GetPet(Guid petId)
        {
            return _pets[petId];
        }

        public Guid AddPet(PetDto petDto)
        {
            var newPet = new Pet(petDto);
            _pets.Add(newPet.Id, newPet);
            return newPet.Id;
        }

        public PetDto RemovePet(Guid petId)
        {
            var removedPet = _pets[petId];
            _pets.Remove(petId);
            return new PetDto(removedPet);
        }

        public Pet UpdatePet(Guid petId, PetDto petDto)
        {
            _pets[petId].Update(petDto);
            return _pets[petId];
        }

        private readonly Dictionary<Guid, Pet> _pets = new Dictionary<Guid, Pet>();
    }
}