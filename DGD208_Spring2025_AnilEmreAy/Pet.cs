using System;

public class Pet
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Health { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }

    public void ApplyEffect(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Health:
                Health = Clamp(Health + amount, 0, 100);
                break;
            case PetStat.Happiness:
                Happiness = Clamp(Happiness + amount, 0, 100);
                break;
            case PetStat.Energy:
                Energy = Clamp(Energy + amount, 0, 100);
                break;
        }
    }

    public void ShowStats()
    {
        Console.WriteLine($"{Name} (Type: {Type}) - Health: {Health}, Happiness: {Happiness}, Energy: {Energy}");
    }

    private int Clamp(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
}

