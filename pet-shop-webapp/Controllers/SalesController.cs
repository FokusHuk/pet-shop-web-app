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
        public SalesController(IPetsRepository petsRepository, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("balance")]
        public IActionResult GetBalance()
        {
            var balance = _userRepository.GetUserBalance();
            var response = new {Balance = balance};
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
            var balance = _userRepository.GetUserBalance();
            if (balance < totalCost)
            {
                throw new Exception($"Недостаточно средств для покупки. Баланс: {balance}. Стоимость: {totalCost}.");
            }

            foreach (var item in items)
            {
                _petsRepository.RemovePet(item);
            }
            
            _cartRepository.RemoveAllItems();

            balance -= totalCost;
            
            _userRepository.ChangeUserBalance(balance);

            var response = new {Balance = balance};
            
            return Ok(response);
        }

        private readonly IPetsRepository _petsRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
    }
}