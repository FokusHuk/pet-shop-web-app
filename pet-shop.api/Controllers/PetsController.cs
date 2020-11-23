using System;
using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;
using pet_shop.api.Extensions;
using pet_shop.api.Filters;
using pet_shop.api.Models;

namespace pet_shop.api.Controllers
{
    [Route("pets")]
    [GlobalExceptionFilter]
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

        [HttpGet]
        [Route("{petId}")]
        public IActionResult GetPet([FromRoute] Guid petId)
        {
            var pet = _petsRepository.GetPet(petId);
            var petModel = pet.Map();
            return Ok(petModel);
        }

        [HttpPost]
        public IActionResult PostPet([FromBody] PostPetRequest request)
        {
            var newPet = request.Map();
            var petId = _petsRepository.AddPet(newPet);
            var response = new {PetId = petId};
            return Ok(response);
        }

        [HttpDelete]
        [Route("{petId}")]
        public IActionResult DeletePet([FromRoute] Guid petId)
        {
            var pet = _petsRepository.RemovePet(petId);
            var response = pet.Map();
            return Ok();
        }
        
        [HttpPut]
        [Route("{petId}")]
        public IActionResult UpdatePet([FromRoute] Guid petId, [FromBody] PutPetRequest request)
        {
            var petDto = request.Map();
            var pet = _petsRepository.UpdatePet(petId, petDto);
            var response = pet.Map();
            return Ok(response);
        }

        private readonly IPetsRepository _petsRepository;
    }
}