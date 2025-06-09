using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class ItemMenu
{
    public static void ShowItems(List<Item> items)
    {
        Console.WriteLine("Available Items:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} - Affects {item.AffectedStat} by {item.EffectAmount} - Price: ${item.Price}");
        }
        Console.ReadKey();
    }

    public static async Task<int> UseItemOnPet(List<Pet> pets, List<Item> items, ItemService itemService, int money)
    {
        if (pets.Count == 0)
        {
            Console.WriteLine("You don't have any pets.");
            Console.ReadKey();
            return money;
        }

        Console.WriteLine("Select a pet:");
        for (int i = 0; i < pets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pets[i]}");
        }

        if (!int.TryParse(Console.ReadLine(), out int petChoice) || petChoice < 1 || petChoice > pets.Count)
        {
            Console.WriteLine("Invalid pet choice.");
            Console.ReadKey();
            return money;
        }

        var selectedPet = pets[petChoice - 1];

        Console.WriteLine("Select an item:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} (${items[i].Price})");
        }

        if (!int.TryParse(Console.ReadLine(), out int itemChoice) || itemChoice < 1 || itemChoice > items.Count)
        {
            Console.WriteLine("Invalid item choice.");
            Console.ReadKey();
            return money;
        }

        var selectedItem = items[itemChoice - 1];

        if (money < selectedItem.Price)
        {
            Console.WriteLine("Not enough money.");
            Console.ReadKey();
            return money;
        }

        money -= selectedItem.Price;
        await itemService.UseItem(selectedPet, selectedItem);
        return money;
    }
}
