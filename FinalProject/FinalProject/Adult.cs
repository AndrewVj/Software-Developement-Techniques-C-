using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Adult : Patient
    {

        private bool cosmeticSurgeryNeeded;
        public Adult()
        {
        }

        public Adult(string name, uint age, string contactNumber, string creditCardNumber) : base(name, age, contactNumber, creditCardNumber)
        {
        }

        public bool CosmeticSurgeryNeeded { 
            get => cosmeticSurgeryNeeded;
            set
            {
                if (value)
                {
                    cosmeticSurgeryNeeded = value;
                    DentalServices += OtherService;
                }

            }
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override string OtherService()
        {
            return "Cosmetic Surgery";
        }
    }
}
