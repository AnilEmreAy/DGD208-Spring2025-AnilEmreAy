using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static string studentName = "Anıl Emre Ay";
    static string studentNumber = "2305041050";
    static int money = 500;

    static void Main()
    {
        List<Pet> myPets = new List<Pet>();
        List<Pet> availablePets = DefaultPets.GetDefaultPets();
        List<Item> items = DefaultItems.GetDefaultItems();
        ItemService itemService = new ItemService();

        Thread statThread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(3000);
                for (int i = myPets.Count - 1; i >= 0; i--)
                {
                    Pet pet = myPets[i];
                    pet.DecreaseStats(1);

                    if (pet.IsDragon && pet.Hunger == 0 && myPets.Count > 1)
                    {
                        Pet victim = myPets.Find(p => p != pet);
                        if (victim != null)
                        {
                            Console.WriteLine($"{pet.Name} the Dragon was starving and ate {victim.Name}.");
                            myPets.Remove(victim);
                            pet.Hunger = 100;
                            continue;
                        }
                    }

                    if (pet.Fun == 0)
                    {
                        Console.WriteLine($"{pet.Name} Your pet ran away from home because you never played with it");
                        myPets.RemoveAt(i);
                    }
                    else if (pet.Hunger == 0 || pet.Sleep == 0)
                    {
                        Console.WriteLine($"{pet.Name} has died.");
                        myPets.RemoveAt(i);
                    }
                }
            }
        });
        statThread.IsBackground = true;
        statThread.Start();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== HOME =====");
            Console.WriteLine($"Money: ${money}");
            Console.WriteLine();
            Console.WriteLine("1. View Pets");
            Console.WriteLine("2. Go To Buy New Pet");
            Console.WriteLine("3. Go To A101");
            Console.WriteLine("4. Use Item on a Pet");
            Console.WriteLine("5. Go to Work");
            Console.WriteLine("6. Look at the ID from your wallet ");
            Console.WriteLine("0. Exit Game");
            Console.Write("Please select an option (0-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PetMenu.ShowPets(myPets);
                    break;

                case "2":
                    PetMenu.AdoptPet(myPets, availablePets, ref money);
                    break;

                case "3":
                    ItemMenu.ShowItems(items);
                    break;

                case "4":
                    money = ItemMenu.UseItemOnPet(myPets, items, itemService, money).Result;
                    break;

                case "5":
                    var result = JobService.Work();
                    Console.WriteLine($"Working... It will take {result.seconds} seconds.");
                    Thread.Sleep(result.seconds * 1000);
                    money += result.money;
                    Console.WriteLine($"You earned ${result.money}.");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.WriteLine();
                    Console.WriteLine($"Created by: {studentName}");
                    Console.WriteLine($"Student Number: {studentNumber}");
                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please enter a number from 0 to 6.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
