using System;

public static class JobService
{
    public static (int money, int seconds) Work()
    {
        Random rand = new Random();
        int earned = rand.Next(20, 70);  
        int time = rand.Next(3, 6);       
        return (earned, time);
    }
}
