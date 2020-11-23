using System;
using System.Data;

namespace pet_shop.api.Domain
{
    public class Pet
    {
        public Pet(Guid id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public void Update(PetDto petDto)
        {
            Name = petDto.Name;
            Description = petDto.Description;
            Price = petDto.Price;
        }
        
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
    }
}