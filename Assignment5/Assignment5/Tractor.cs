using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Tractor : Vehicle
    {
        public Tractor()
        {
        }

        public Tractor(int yearOfMake, string company, string model, string associatedCreditCardNumber) : base(yearOfMake, company, model, associatedCreditCardNumber)
        {
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override string AdditionalService()
        {
            return "PTO Maintenance";
        }

        public override string ToString()
        {
            return $"Tractor {base.ToString()}\n{AdditionalService()}";
        }
    }
}
