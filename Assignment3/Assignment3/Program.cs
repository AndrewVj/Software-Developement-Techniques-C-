using System;
using System.Collections;

namespace Assignment3
{
    class Program
    {
        enum Vehicles
        {
            //The values will now start from 1 instead of 0
            Car = 1,
            SchoolBus,
            PickUpTruck,
            Tractor
        }

        enum AppointmentSlots
        {
            //The values will now start from 1 instead of 0
            am8 = 1,
            am9,
            am10,
            am11,
            am12,
            pm1,
            pm2,
            pm3,
            pm4,
            pm5
        }
        static void Main(string[] args)
        {
            Program p = new();
            p.Go();
            Console.ReadKey();
        }

        public void Go()
        {
            var slotValues = Enum.GetValues(typeof(AppointmentSlots));
            Hashtable availableSlots = new();
            //Create a hashtable and store the slot number as key and slot timing(in string) as value
            foreach (AppointmentSlots value in slotValues)
            {
                string time = value.ToString();
                string hours = time.Substring(2);
                string amOrPm = time.Substring(0, 2).ToUpper();
                string finalTime = $"{hours}:00 {amOrPm}";
                availableSlots.Add((int)value, finalTime);
            }


            //Since we implemented IDisposable Interface in AppointmentList
            using(AppointmentList appointments = new())
            {
                while (true)
                {
                    string appointmentNeeded = string.Empty;
                    do
                    {
                        Console.Write("Do you need to book an appointment?[Y/N]: ");
                        appointmentNeeded = Console.ReadLine().ToUpper();
                    } while ((appointmentNeeded != "Y") && (appointmentNeeded != "N"));

                    if (appointmentNeeded == "N")
                    {
                        break;
                    }

                    Console.WriteLine("\nAvailable appointments: ");
                    //Print the list of availale appointments
                    foreach (int slotNo in slotValues)
                    {
                        if (availableSlots.ContainsKey(slotNo))
                        {
                            Console.WriteLine($"[{slotNo}] {availableSlots[slotNo]}");
                        }
                    }

                    int slotChoice = GetSlotChoice(availableSlots);
                    if (slotChoice == 0)
                    {
                        break;
                    }

                    int vehicleChoice = GetVehicleChoice();
                    if (vehicleChoice == 0)
                    {
                        break;
                    }

                    int yearOfMake = 0;
                    string company = string.Empty;
                    string model = string.Empty;
                    string creditCard = string.Empty;
                    Vehicle customer = null;
                    //Got the vehicle details, created a new instance of respective derived class(Car, Truck, Bus, Tractor)
                    //And store the object/instance appointments(AppointmentList) we created earlier
                    //Removed the slot from the available slots(Hashtable) since the slot is now taken
                    switch (vehicleChoice)
                    {
                        case (int)Vehicles.Car:
                            Console.Write("Car's year of make: ");
                            yearOfMake = GetYearOfMake();
                            Console.Write("Car's manufacturing Company: ");
                            company = Console.ReadLine();
                            Console.Write("Car's model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter your credit card number: ");
                            creditCard = GetCreditCardNumber();

                            customer = new Car(yearOfMake, company, model, creditCard);
                            //Creating a new instance of Appointment and storing it in appointments(AppointmentList).
                            //Using AppointmentList like a regular List because we used Indexer.
                            appointments.Add(new Appointment(slotChoice, availableSlots[slotChoice].ToString(), customer));
                            availableSlots.Remove(slotChoice);
                            break;

                        case (int)Vehicles.PickUpTruck:
                            Console.Write("Pick up truck's year of make: ");
                            yearOfMake = GetYearOfMake();
                            Console.Write("Pick up truck's manufacturing Company: ");
                            company = Console.ReadLine();
                            Console.Write("Pick up truck's model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter your credit card number: ");
                            creditCard = GetCreditCardNumber();

                            customer = new PickUpTruck(yearOfMake, company, model, creditCard);
                            appointments.Add(new Appointment(slotChoice, availableSlots[slotChoice].ToString(), customer));
                            availableSlots.Remove(slotChoice);
                            break;

                        case (int)Vehicles.SchoolBus:
                            Console.Write("School bus's year of make: ");
                            yearOfMake = GetYearOfMake();
                            Console.Write("School bus's manufacturing Company: ");
                            company = Console.ReadLine();
                            Console.Write("School bus's model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter your credit card number: ");
                            creditCard = GetCreditCardNumber();

                            customer = new SchoolBus(yearOfMake, company, model, creditCard);
                            appointments.Add(new Appointment(slotChoice, availableSlots[slotChoice].ToString(), customer));
                            availableSlots.Remove(slotChoice);
                            break;

                        case (int)Vehicles.Tractor:
                            Console.Write("Tractor's year of make: ");
                            yearOfMake = GetYearOfMake();
                            Console.Write("Tractor's manufacturing Company: ");
                            company = Console.ReadLine();
                            Console.Write("Tractor's model: ");
                            model = Console.ReadLine();
                            Console.Write("Enter your credit card number: ");
                            creditCard = GetCreditCardNumber();

                            customer = new Tractor(yearOfMake, company, model, creditCard);
                            appointments.Add(new Appointment(slotChoice, availableSlots[slotChoice].ToString(), customer));
                            availableSlots.Remove(slotChoice);
                            break;

                        default:
                            break;
                    }

                    //We exit the loop if no slots are available
                    if (availableSlots.Count == 0)
                    {
                        Console.WriteLine("No more slots available for the day. Try to book a slot on someother day.");
                        break;
                    }
                }

                //Sorting the appointments based on Slot No.
                //Possible because we implemented IComparable Interface for Appointments and Indexer in Appointment List
                appointments.Sort();

                //Iterate over each appointment in the AppointmentList using foreach
                //Possible because we implemented IEnumerable interface
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine($"\nSlot No: {appointment.SlotNo} - {appointment.AppointmentTime}");
                    Console.WriteLine(appointment.CustomerVehicle);
                    Console.WriteLine("The following services were performed on your vehicle: ");
                    //Using delegates to print all the methods associated with CustomerVehicle
                    appointment.CustomerVehicle.VehicleServicesDelegate();
                    Console.WriteLine();
                }
            }            
        }

        //To check if valid slot choice is entered
        private int GetSlotChoice(Hashtable availableSlots)
        {
            int slotChoice = 0;
            while (true)
            {
                Console.Write("Choose a slot from the above list to book an appointment:[0 to exit] ");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out slotChoice))
                {
                    if (slotChoice == 0)
                    {
                        return 0;
                    }

                    if (availableSlots.ContainsKey(slotChoice))
                    {
                        return slotChoice;
                    }
                }
            }
        }

        //To check if valid vehicle choice is entered
        private int GetVehicleChoice()
        {
            int vehicleChoice = 0;
            Console.WriteLine("\nChoose your vehicle type:\nThe following vehicles are serviced here..");
            Console.WriteLine("1.Car\n2.School Bus\n3.Pick Up Truck\n4.Tractor");

            do
            {
                Console.Write("Choose your vehicle [Enter 0 to exit.]: ");
            } while (!int.TryParse(Console.ReadLine(), out vehicleChoice) || vehicleChoice < 0 || vehicleChoice > Enum.GetValues(typeof(Vehicles)).Length);
            Console.WriteLine();

            return vehicleChoice;
        }

        //To check if valid year of make is entered
        private int GetYearOfMake()
        {
            int yearOfMake = 0;
            while (!int.TryParse(Console.ReadLine(), out yearOfMake) || yearOfMake < 1900 || yearOfMake > 2023)
            {
                Console.Write("Enter a valid year: ");
            }
            return yearOfMake;
        }

        //To check if valid credit card information is entered
        private string GetCreditCardNumber()
        {
            long creditCardNo = 0;
            while (!long.TryParse(Console.ReadLine(), out creditCardNo) || creditCardNo.ToString().Length != 16)
            {
                Console.Write("Enter a valid 16 digit credit card number: ");
            }
            return creditCardNo.ToString();
        }
    }
}
