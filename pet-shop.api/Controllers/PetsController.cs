using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;
using pet_shop.api.Extensions;

namespace pet_shop.api.Controllers
{
    [Route("pets")]
    public class PetsController: ControllerBase
    {
        public PetsController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _petsRepository.GetPets();
            var petModels = pets.Map();
            return Ok(petModels);
        }

        private readonly IPetsRepository _petsRepository;
    }
}