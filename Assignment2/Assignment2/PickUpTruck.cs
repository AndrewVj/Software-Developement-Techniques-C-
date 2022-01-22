using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class PickUpTruck: Vehicle
    {
        public PickUpTruck()
        {
        }

        public PickUpTruck(int yearOfMake, string company, string model, string creditCardNumber) : base(yearOfMake, company, model, creditCardNumber)
        {
        }

        public override string ToString()
        {
            return $"Pick Up Truck {base.ToString()}";
        }

        public void InstallationOfCover()
        {
            Console.WriteLine("Cover Installed.");
        }
    }
}
