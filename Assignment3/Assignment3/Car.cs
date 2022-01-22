using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Car: Vehicle
    {
        public Car()
        {
        }

        public Car(int yearOfMake, string company, string model, string associatedCreditCardNumber) : base(yearOfMake, company, model, associatedCreditCardNumber)
        {
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override void AdditionalService()
        {
            Console.WriteLine("Body Tuned Up.");
        }

        public override string ToString()
        {
            return $"Car {base.ToString()}";
        }
    }
}
