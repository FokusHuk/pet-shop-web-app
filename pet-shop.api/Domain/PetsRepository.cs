using System;
using System.Collections.Generic;
using System.Linq;

namespace pet_shop.api.Domain
{
    public class PetsRepository: IPetsRepository
    {
        public IEnumerable<PetDto> GetPets()
        {
            return _pets.Select(petInDict => new PetDto(petInDict.Value));
        }

        public PetDto GetPet(Guid petId)
        {
            return new PetDto(_pets[petId]);
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

        public void UpdatePet(PetDto petDto)
        {
            _pets[petDto.Id].Update(petDto);
        }

        private readonly Dictionary<Guid, Pet> _pets = new Dictionary<Guid, Pet>();
    }
}