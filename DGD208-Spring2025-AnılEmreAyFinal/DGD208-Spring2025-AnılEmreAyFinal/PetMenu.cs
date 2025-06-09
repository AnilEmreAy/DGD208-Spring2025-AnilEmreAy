using System;
using System.Collections.Generic;

public static class PetMenu
{
    public static void ShowPets(List<Pet> pets)
    {
        Console.WriteLine("Your Pets:");
        if (pets.Count == 0)
        {
            Console.WriteLine("You don't have any pets.");
        }
        else
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
        Console.ReadKey();
    }

    public static void AdoptPet(List<Pet> adopted, List<Pet> available, ref int money)
    {
        Console.WriteLine("Available Pets:");
        for (int i = 0; i < available.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {available[i].Name} ({available[i].Type}) - ${available[i].Price}");
        }

        Console.Write("Choose a pet to adopt: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= available.Count)
        {
            var selectedPet = available[choice - 1];
            if (money >= selectedPet.Price)
            {
                adopted.Add(new Pet
                {
                    Name = selectedPet.Name,
                    Type = selectedPet.Type,
                    Hunger = 50,
                    Sleep = 50,
                    Fun = 50,
                    Price = selectedPet.Price
                });
                money -= selectedPet.Price;
                Console.WriteLine($"{selectedPet.Name} has been adopted!");
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Console.ReadKey();
    }
}
