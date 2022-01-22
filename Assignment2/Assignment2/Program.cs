using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
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

            //Create an appointment array and initialise the appointment objects in the array. And link the slots with the appointments
            Appointment[] customerAppointments = new Appointment[slotValues.Length];
            for (int i = 0; i < customerAppointments.Length; i++)
            {
                customerAppointments[i] = new();
                customerAppointments[i].SlotNo = i + 1;
                customerAppointments[i].AppointmentDate = availableSlots[i + 1].ToString();
                
            }

            while (true)
            {
                string appointmentNeeded = string.Empty;
                do
                {
                    Console.Write("Do you need to book an appointment?[Y/N]: ");
                    appointmentNeeded = Console.ReadLine().ToUpper();
                } while ((appointmentNeeded != "Y") && (appointmentNeeded != "N"));
                
                if(appointmentNeeded == "N")
                {
                    break;
                }

                Console.WriteLine("\nAvailable appointments: ");
                //Print the list of availale appointments
                foreach(int slotNo in slotValues)
                {
                    if (availableSlots.ContainsKey(slotNo))
                    {
                        Console.WriteLine($"[{slotNo}] {availableSlots[slotNo]}");
                    }
                }

                int slotChoice = GetSlotChoice(availableSlots);
                if(slotChoice == 0)
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
                //And stored the object/instance as a Vehicle type in the appointmentArray we created earlier
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
                        customerAppointments[slotChoice-1].CustomerVehicle = customer;
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
                        customerAppointments[slotChoice - 1].CustomerVehicle = customer;
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
                        customerAppointments[slotChoice - 1].CustomerVehicle = customer;
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
                        customerAppointments[slotChoice - 1].CustomerVehicle = customer;
                        availableSlots.Remove(slotChoice);
                        break;

                    default:
                        break;
                }

                if(availableSlots.Count == 0)
                {
                    Console.WriteLine("No more slots available for the day. Try to book a slot on someother day.");
                    break;
                }
            }


            //Itereating over the appointments we print the deatils of the appointment that have been booked.
            //ApointmentArray contains the list of customers.
            foreach (var customerAppoinment in customerAppointments)
            {
                Vehicle customerVehicle = customerAppoinment.CustomerVehicle;
                if (customerVehicle == null)
                {
                    continue;
                }

                Console.WriteLine($"\nSlot No: {customerAppoinment.SlotNo} - {customerAppoinment.AppointmentDate}");
                Console.WriteLine(customerVehicle);
                Console.WriteLine("The following services were performed on your vehicle: ");
                customerVehicle.OilChange();
                customerVehicle.EngineTuneUp();
                customerVehicle.TransmissionCleanUp();

                string type = customerVehicle.GetType().ToString().Substring(12);
                //We cast the objects as their respective derived class objects and print their unique methods.
                switch (type)
                {
                    case "Car":
                        Car car = (Car)customerVehicle;
                        car.BodyTuneUp();
                        Console.WriteLine();
                        break;

                    case "PickUpTruck":
                        PickUpTruck truck = (PickUpTruck)customerVehicle;
                        truck.InstallationOfCover();
                        Console.WriteLine();
                        break;

                    case "SchoolBus":
                        SchoolBus bus = (SchoolBus)customerVehicle;
                        bus.InteriorCleanUp();
                        Console.WriteLine();
                        break;

                    case "Tractor":
                        Tractor tractor = (Tractor)customerVehicle;
                        tractor.PTOMaintenance();
                        Console.WriteLine();
                        break;

                    default:
                        break;
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

                if(int.TryParse(choice, out slotChoice))
                {
                    if(slotChoice == 0)
                    {
                        return 0;
                    }

                    if(availableSlots.ContainsKey(slotChoice))
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
            while(!int.TryParse(Console.ReadLine(),out yearOfMake) || yearOfMake < 1900 || yearOfMake > 2023)
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
