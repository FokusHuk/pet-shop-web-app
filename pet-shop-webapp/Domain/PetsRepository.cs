using System;
using System.Collections.Generic;
using System.Linq;

namespace pet_shop.api.Domain
{
    public class PetsRepository: IPetsRepository
    {
        public PetsRepository()
        {
            LoadTestData();
        }
        
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

        private void LoadTestData()
        {
            var pet1 = new Pet("Cat", "White and fluffy", 1200);
            var pet2 = new Pet("Dog", "Black and kind", 1000);
            var pet3 = new Pet("Turtle", "Small, cute and brown-green", 3400);
            var pet4 = new Pet("Parrot", "Funny and silly", 2500);
            var pet5 = new Pet("Fish", "Silent and strange", 800);
            _pets.Add(pet1.Id, pet1);
            _pets.Add(pet2.Id, pet2);
            _pets.Add(pet3.Id, pet3);
            _pets.Add(pet4.Id, pet4);
            _pets.Add(pet5.Id, pet5);
        }

        private readonly Dictionary<Guid, Pet> _pets = new Dictionary<Guid, Pet>();
    }
}