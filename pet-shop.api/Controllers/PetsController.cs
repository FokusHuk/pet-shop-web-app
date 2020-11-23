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
            return Ok(pets);
        }

        [HttpGet]
        [Route("{petId}")]
        public IActionResult GetPet([FromRoute] Guid petId)
        {
            var pet = _petsRepository.GetPet(petId);
            return Ok(pet);
        }

        [HttpPost]
        public IActionResult PostPet([FromBody] GeneralPetRequest request)
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
            return Ok(response);
        }
        
        [HttpPut]
        [Route("{petId}")]
        public IActionResult UpdatePet([FromRoute] Guid petId, [FromBody] GeneralPetRequest request)
        {
            var petDto = request.Map();
            petDto.Id = petId;
            _petsRepository.UpdatePet(petDto);
            return Ok();
        }

        private readonly IPetsRepository _petsRepository;
    }
}