using System;

namespace Assignment1
{
    enum SeatOptions
    {
        Purple = 50,
        Green = 80,
        Blue = 100
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new();
            p.Go();
            Console.ReadKey();
        }

        public void Go()
        {
            var options = Enum.GetValues(typeof(SeatOptions));
            int totalCost = 0;

            Console.WriteLine("Hello Joe!!");

            int purpleTicketCount = getValidIntValue("Enter the number of purple seat tickets you bought this season: ");
            int greenTicketCount = getValidIntValue("Enter the number of green seat tickets you bought this season: ");
            int blueTicketCount = getValidIntValue("Enter the number of blue seat tickets you bought this season: ");

            foreach(SeatOptions option in options)
            {
                switch (option)
                {
                    case SeatOptions.Purple:
                        totalCost += ((int)SeatOptions.Purple * purpleTicketCount);
                        break;
                    case SeatOptions.Green:
                        totalCost += ((int)SeatOptions.Green * greenTicketCount);
                        break;
                    case SeatOptions.Blue:
                        totalCost += ((int)SeatOptions.Blue * blueTicketCount);
                        break;
                    default:
                        break;
                }
            }

            double avgTicketCost = (double)totalCost / (purpleTicketCount + greenTicketCount + blueTicketCount);

            Console.WriteLine($"You've spent a total amount of ${totalCost} this season, while spending an average of ${avgTicketCost:f} on each game ticket.");
        }

        public int getValidIntValue(string prompt)
        {
            int value = int.MinValue;
            bool success = false;
            Console.Write(prompt);

            while(!success)
            {
                success = int.TryParse(Console.ReadLine(), out value);

                if(value < 0)
                {
                    success = false;
                }

                if (!success)
                {
                    Console.Write(prompt);
                }
            }
            
            return value;
        }
    }
}
