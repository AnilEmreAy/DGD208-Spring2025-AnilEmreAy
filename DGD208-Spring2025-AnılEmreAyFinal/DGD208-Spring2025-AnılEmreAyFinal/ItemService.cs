using System;
using System.Threading.Tasks;

public class ItemService
{
    public async Task UseItem(Pet pet, Item item)
    {
        Console.WriteLine($"Using {item.Name} on {pet.Name}...");
        await Task.Delay((int)(item.Duration * 1000));
        pet.IncreaseStat(item.AffectedStat, item.EffectAmount);
        Console.WriteLine($"{item.Name} used. {pet.Name}'s {item.AffectedStat} increased by {item.EffectAmount}.");
        Console.ReadKey();
    }
}
