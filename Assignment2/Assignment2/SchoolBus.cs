using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class SchoolBus: Vehicle
    {
        public SchoolBus()
        {
        }

        public SchoolBus(int yearOfMake, string company, string model, string creditCardNumber) : base(yearOfMake, company, model, creditCardNumber)
        {
        }

        public override string ToString()
        {
            return $"School Bus {base.ToString()}";
        }

        public void InteriorCleanUp()
        {
            Console.WriteLine("Interior Cleaned Up.");
        }
    }
}
