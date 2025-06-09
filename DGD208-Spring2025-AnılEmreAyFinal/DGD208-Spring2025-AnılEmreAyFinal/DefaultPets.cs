using System.Collections.Generic;

public static class DefaultPets
{
    public static List<Pet> GetDefaultPets()
    {
        return new List<Pet>
        {
            new Pet { Name = "Cat", Type = PetType.Cat, Price = 300 },
            new Pet { Name = "Dog", Type = PetType.Dog, Price = 300 },
            new Pet { Name = "Snake", Type = PetType.Snake, Price = 500 },
            new Pet { Name = "Dragon", Type = PetType.Dragon, Price = 1000 }
        };
    }
}
