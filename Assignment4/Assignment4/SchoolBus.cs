using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class SchoolBus : Vehicle
    {
        public SchoolBus()
        {
        }

        public SchoolBus(int yearOfMake, string company, string model, string associatedCreditCardNumber) : base(yearOfMake, company, model, associatedCreditCardNumber)
        {
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override string AdditionalService()
        {
            return "Interior Cleaned Up.";
        }

        public override string ToString()
        {
            return $"School Bus {base.ToString()}\n{AdditionalService()}";
        }
    }
}
