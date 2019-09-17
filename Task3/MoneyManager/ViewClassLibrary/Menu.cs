using System;

namespace ViewClassLibrary
{
    public class Menu
    {
        public void StartMenu()
        {
            Console.WriteLine("   Welcome to Money Manager   ");
            Console.WriteLine("1. Show All users");
            Console.WriteLine("2. Delete, update, create any entity");
            Console.WriteLine("0. Exit");
            string userEnter = Console.ReadLine();

            while (true)
            {
                switch (userEnter)
                {
                    case "1": break;
                    case "2": break;
                    case "0": return;
                }
            }
        }
    }
}
