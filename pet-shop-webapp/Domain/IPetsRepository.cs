using System;
using System.Collections.Generic;

namespace pet_shop.api.Domain
{
    public interface IPetsRepository
    {
        public IEnumerable<PetDto> GetPets();
        public PetDto GetPet(Guid petId);
        public Guid AddPet(PetDto petDto);
        public PetDto RemovePet(Guid petId);
        public void UpdatePet(PetDto petDto);
    }
}