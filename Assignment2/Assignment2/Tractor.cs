using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Tractor: Vehicle
    {
        public Tractor()
        {
        }

        public Tractor(int yearOfMake, string company, string model, string creditCardNumber) : base(yearOfMake, company, model, creditCardNumber)
        {
        }

        public override string ToString()
        {
            return $"Tractor {base.ToString()}";
        }

        public void PTOMaintenance()
        {
            Console.WriteLine("PTO Maintenance Done.");
        }
    }
}
