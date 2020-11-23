using System;

namespace pet_shop.api.Models
{
    public class GetPetsResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}