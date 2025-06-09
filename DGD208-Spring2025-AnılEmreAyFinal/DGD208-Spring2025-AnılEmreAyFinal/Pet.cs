using System;

public class Pet
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Hunger { get; set; } = 50;
    public int Sleep { get; set; } = 50;
    public int Fun { get; set; } = 50;
    public int Price { get; set; }

    public bool IsDragon => Type == PetType.Dragon;

    public void DecreaseStats(int amount)
    {
        Hunger = Math.Max(0, Hunger - amount);
        Sleep = Math.Max(0, Sleep - amount);
        Fun = Math.Max(0, Fun - amount);
    }

    public void IncreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger:
                Hunger = Math.Min(100, Hunger + amount);
                break;
            case PetStat.Sleep:
                Sleep = Math.Min(100, Sleep + amount);
                break;
            case PetStat.Fun:
                Fun = Math.Min(100, Fun + amount);
                break;
        }
    }

    public override string ToString()
    {
        return $"{Name} ({Type}) - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}";
    }
}
