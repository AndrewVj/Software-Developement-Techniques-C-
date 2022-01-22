using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class PickUpTruck : Vehicle
    {
        public PickUpTruck()
        {
        }

        public PickUpTruck(int yearOfMake, string company, string model, string associatedCreditCardNumber) : base(yearOfMake, company, model, associatedCreditCardNumber)
        {
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override void AdditionalService()
        {
            Console.WriteLine("Cover Installed.");
        }

        public override string ToString()
        {
            return $"Pick Up Truck {base.ToString()}";
        }
    }
}
