using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;
using pet_shop.api.Filters;

namespace pet_shop.api.Controllers
{
    [Route("cart")]
    [GlobalExceptionFilter]
    public class CartController: ControllerBase
    {
        public CartController(IPetsRepository petsRepository, ICartRepository cartRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _cartRepository.GetItems();
            var pets = items.Select(item => _petsRepository.GetPet(item));
            return Ok(pets);
        }

        [HttpPost]
        [Route("{petId}")]
        public IActionResult PostItem([FromRoute] Guid petId)
        {
            _cartRepository.AddItem(petId);
            var petDto = _petsRepository.GetPet(petId);
            return Ok(petDto);
        }
        
        [HttpDelete]
        [Route("{petId}")]
        public IActionResult DeleteItem([FromRoute] Guid petId)
        {
            _cartRepository.RemoveItem(petId);
            var petDto = _petsRepository.GetPet(petId);
            return Ok(petDto);
        }
        
        [HttpDelete]
        public IActionResult DeleteItems()
        {
            _cartRepository.RemoveAllItems();
            return Ok();
        }

        private readonly IPetsRepository _petsRepository;
        private readonly ICartRepository _cartRepository;
    }
}