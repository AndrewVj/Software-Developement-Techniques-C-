using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Child : Patient
    {
        private bool babyToothExtractionNeeded;
        public Child()
        {
        }

        public Child(string name, uint age, string contactNumber, string creditCardNumber) : base(name, age, contactNumber, creditCardNumber)
        {
        }

        public bool BabyToothExtractionNeeded { 
            get => babyToothExtractionNeeded;
            set
            {
                if (value)
                {
                    babyToothExtractionNeeded = value;
                    DentalServices += OtherService;
                }

            }
        }

        //Overriding the abstract method from Base class to implement unique derived class functionality
        public override string OtherService()
        {
            return "Baby Tooth Extraction";
        }
    }
}
