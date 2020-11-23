namespace pet_shop.api.Domain
{
    public class PetDto
    {
        public PetDto(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public PetDto(Pet pet)
        {
            Name = pet.Name;
            Description = pet.Description;
            Price = pet.Price;
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}