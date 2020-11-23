using System;
using System.Collections.Generic;

namespace pet_shop.api.Domain
{
    public interface IPetsRepository
    {
        public IEnumerable<Pet> GetPets();
        public Pet GetPet(Guid petId);
        public Guid AddPet(PetDto petDto);
        public PetDto RemovePet(Guid petId);
        public Pet UpdatePet(Guid petId, PetDto petDto);
    }
}