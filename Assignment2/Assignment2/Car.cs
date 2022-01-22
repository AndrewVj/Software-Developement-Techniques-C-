using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Car: Vehicle
    {
        public Car()
        {
        }

        public Car(int yearOfMake, string company, string model, string creditCardNumber) : base(yearOfMake, company, model, creditCardNumber)
        {
        }

        public override string ToString()
        {
            return $"Car {base.ToString()}";
        }

        public void BodyTuneUp()
        {
            Console.WriteLine("Body Tuned Up.");
        }
    }
}
