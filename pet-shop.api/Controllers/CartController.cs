using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;

namespace pet_shop.api.Controllers
{
    [Route("cart")]
    public class CartController: ControllerBase
    {
        public CartController(IPetsRepository petsRepository, ICartRepository cartRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
        }

        private readonly IPetsRepository _petsRepository;
        private readonly ICartRepository _cartRepository;
    }
}