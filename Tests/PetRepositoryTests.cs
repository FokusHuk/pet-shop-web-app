using NUnit.Framework;
using pet_shop.api.Domain;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void GetPet_WithInMemoryData_CorrectPrice()
        {
            var petsRepository = new PetsRepository();

            var petId = petsRepository.AddPet(new PetDto("Test", "Test description", 1000));
            var pet = petsRepository.GetPet(petId);
            
            Assert.AreEqual(1000, pet.Price);
        }
    }
}