using System.Collections;
using System.Collections.Generic;

namespace pet_shop.api.Domain
{
    public interface IPetsRepository
    {
        public IEnumerable<Pet> GetPets();
    }
}