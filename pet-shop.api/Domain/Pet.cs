using System;
using System.Data;

namespace pet_shop.api.Domain
{
    public class Pet
    {
        public Pet(string name, string description, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }

        public Pet(PetDto petDto)
        {
            Id = Guid.NewGuid();
            Name = petDto.Name;
            Description = petDto.Description;
            Price = petDto.Price;
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