using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //An abstract class that implements IVehicle Interface with one abstract method.
    //Abstract method will be overridden in Derived classes to implement extra functionality
    abstract class Vehicle : IVehicle
    {
        private int yearOfMake;
        private string company;
        private string model;
        private string associatedCreditCardNumber;
        private VehicleDelegate myDelegate = null;

        public int YearOfMake { get => yearOfMake; set => yearOfMake = value; }
        public string Company { get => company; set => company = value; }
        public string Model { get => model; set => model = value; }
        public string AssociatedCreditCardNumber { get => associatedCreditCardNumber; set => associatedCreditCardNumber = value; }
        public VehicleDelegate VehicleServicesDelegate { get => myDelegate; set => myDelegate = value; }

        public Vehicle()
        {
            SetUpDelegate();
        }

        public Vehicle(int yearOfMake, string company, string model, string associatedCreditCardNumber)
        {
            this.yearOfMake = yearOfMake;
            this.company = company;
            this.model = model;
            this.associatedCreditCardNumber = associatedCreditCardNumber;
            SetUpDelegate();
        }

        private void SetUpDelegate()
        {
            myDelegate += OilChange;
            myDelegate += EngineTuneUp;
            myDelegate += TransmissionCleanUp;
            myDelegate += AdditionalService;
        }

        //Abstract method that will be overridden in respective derived classes
        public abstract void AdditionalService();

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

        //Get a secure credit card information
        private string GetSecureCreditCardDetail()
        {
            string protectedCreditInfo = $"{associatedCreditCardNumber.Substring(0, 4)}XXXXXXXX{associatedCreditCardNumber.Substring(12)}";
            return protectedCreditInfo;
        }

        public override string ToString()
        {
            return $"Details -> Manufacturing Company: {Company} | Model: {Model} | Year Of Make: {YearOfMake} | Credit Card linked to the customer:{GetSecureCreditCardDetail()}";
        }
    }
}
