using Microsoft.AspNetCore.Mvc;
using pet_shop.api.Domain;

namespace pet_shop.api.Controllers
{
    [Route("pets")]
    public class PetsController: ControllerBase
    {
        public PetsController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        private readonly IPetsRepository _petsRepository;
    }
}