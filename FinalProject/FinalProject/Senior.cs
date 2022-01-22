using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Senior : Patient
    {
        private bool dentalImplantsNeeded;
        public Senior()
        {
        }

        public Senior(string name, uint age, string contactNumber, string creditCardNumber) : base(name, age, contactNumber, creditCardNumber)
        {
        }

        public bool DentalImplantsNeeded { 
            get => dentalImplantsNeeded;
            set
            {
                if (value)
                {
                    dentalImplantsNeeded = value;
                    DentalServices += OtherService;
                }

            }
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override string OtherService()
        {
            return "Dental Implants";
        }
    }
}
