using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Go();
            Console.ReadKey();
        }

        public void Go()
        {
            Console.Write("Which country did you fly from? ");
            var country = Console.ReadLine();

            Console.Write("How many bags did you have with you? ");
            var noOfBags = int.Parse(Console.ReadLine());

            Console.Write("What was the total weight of your luggage? ");
            var totalWeight = float.Parse(Console.ReadLine());

            var avgWeight = totalWeight / noOfBags;

            Console.WriteLine($"I flew from {country} having {noOfBags} bags with an average weight of {avgWeight:f}.");
        }
    }
}
