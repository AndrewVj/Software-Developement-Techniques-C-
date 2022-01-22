using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Vehicle
    {
        private int yearOfMake;
        private string company;
        private string model;
        private string creditCardNumber;

        public Vehicle()
        {
        }

        public Vehicle(int yearOfMake, string company, string model, string creditCardNumber)
        {
            this.yearOfMake = yearOfMake;
            this.company = company;
            this.model = model;
            this.creditCardNumber = creditCardNumber;
        }

        public int YearOfMake { get => yearOfMake; set => yearOfMake = value; }
        public string Company { get => company; set => company = value; }
        public string Model { get => model; set => model = value; }
        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }

        public void OilChange()
        {
            Console.WriteLine("Oil Changed.");
        }

        public void EngineTuneUp()
        {
            Console.WriteLine("Engine Tuned Up.");
        }

        public void TransmissionCleanUp()
        {
            Console.WriteLine("Transmission Cleaned Up.");
        }
        
        //Concealing the credit card details and returning it.
        private string GetSecureCreditCardDetail()
        {
            string protectedCreditInfo = $"{CreditCardNumber.Substring(0, 4)}XXXXXXXX{CreditCardNumber.Substring(12)}";
            return protectedCreditInfo;
        }

        public override string ToString()
        {
            return $"Details -> Manufacturing Company: {Company} | Model: {Model} | Year Of Make: {YearOfMake} | Credit Card linked to the customer:{GetSecureCreditCardDetail()}";
        }
    }
}
