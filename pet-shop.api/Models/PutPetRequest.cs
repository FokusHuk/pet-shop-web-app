﻿namespace pet_shop.api.Models
{
    public class PutPetRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}