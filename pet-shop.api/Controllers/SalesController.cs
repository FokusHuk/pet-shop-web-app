using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;
using pet_shop.api.Filters;

namespace pet_shop.api.Controllers
{
    [Route("sales")]
    [GlobalExceptionFilter]
    public class SalesController: ControllerBase
    {
        public SalesController(IPetsRepository petsRepository, ICartRepository cartRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("balance")]
        public IActionResult GetBalance()
        {
            var response = new {Balance = _balance};
            return Ok(response);
        }

        [HttpGet]
        [Route("cost")]
        public IActionResult GetTotalCost()
        {
            var items = _cartRepository.GetItems();
            var totalCost = items
                .Select(item => _petsRepository.GetPet(item).Price)
                .Sum(price => price);
            var response = new {TotalCost = totalCost};
            return Ok(response);
        }

        [HttpPost]
        public IActionResult BuyPets()
        {
            var items = _cartRepository.GetItems();
            var totalCost = items
                .Select(item => _petsRepository.GetPet(item).Price)
                .Sum(price => price);
            if (_balance < totalCost)
            {
                throw new Exception($"Недостаточно средств для покупки. Баланс: {_balance}. Стоимость: {totalCost}.");
            }

            foreach (var item in items)
            {
                _petsRepository.RemovePet(item);
            }
            
            _cartRepository.RemoveAllItems();

            _balance -= totalCost;

            var response = new {Balance = _balance};
            
            return Ok(response);
        }

        private readonly IPetsRepository _petsRepository;
        private readonly ICartRepository _cartRepository;
        private double _balance = 10000;
    }
}