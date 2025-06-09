using System.Collections.Generic;

public static class DefaultItems
{
    public static List<Item> GetDefaultItems()
    {
        return new List<Item>
        {
            new Item { Name = "Basic Food", AffectedStat = PetStat.Hunger, EffectAmount = 25, Duration = 2f, Price = 100 },
            new Item { Name = "Deluxe Food", AffectedStat = PetStat.Hunger, EffectAmount = 40, Duration = 3f, Price = 160 },
            new Item { Name = "Soft Pillow", AffectedStat = PetStat.Sleep, EffectAmount = 30, Duration = 3f, Price = 120 },
            new Item { Name = "Energy Drink(Of course it's suitable for animals, I guess...)", AffectedStat = PetStat.Sleep, EffectAmount = 50, Duration = 4f, Price = 200 },
            new Item { Name = "Basic Ball", AffectedStat = PetStat.Fun, EffectAmount = 35, Duration = 2.5f, Price = 140 },
            new Item { Name = "Ultra Elastic Super Ball", AffectedStat = PetStat.Fun, EffectAmount = 60, Duration = 3.5f, Price = 240 }
        };
    }
}
