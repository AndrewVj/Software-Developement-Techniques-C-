using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProject
{
    //An abstract class that implements IPatient Interface with one abstract method.
    //Abstract method will be overridden in Derived classes to implement extra functionality
    public abstract class Patient : IPatient
    {

        private string name;
        private uint age;
        private string contactNumber;
        private string creditCardNumber;
        private string concealedCCNumber;

        
        private DentalServicesDelegate dentalServices = null;

        private bool regularCheckUp;
        private bool cavityFillingNeeded;
        private bool cleaningNeeded;
        private bool toothExtractionNeeded;

        public Patient()
        {
        }

        public Patient(string name, uint age, string contactNumber, string creditCardNumber)
        {
            this.name = name;
            this.age = age;
            this.contactNumber = contactNumber;
            this.creditCardNumber = creditCardNumber;
            this.regularCheckUp = true;
            this.concealedCCNumber = concealedCreditCardNumber();
            SetupDentalServiesDelegate();
        }

        public string Name { get => name; set => name = value; }
        public uint Age { get => age; set => age = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }
        public string ConcealedCCNumber { get => concealedCCNumber; set => concealedCCNumber = value; }
        [XmlIgnore]
        public DentalServicesDelegate DentalServices { get => dentalServices; set => dentalServices = value; }


        public bool CavityFillingNeeded
        {
            get => cavityFillingNeeded;
            set
            {
                if (value)
                {
                    cavityFillingNeeded = value;
                    DentalServices += CavityFilling;
                }

            }
        }

        public bool CleaningNeeded
        {
            get => cleaningNeeded;
            set
            {
                if (value)
                {
                    cleaningNeeded = value;
                    DentalServices += Cleaning;
                }

            }
        }

        public bool ToothExtractionNeeded
        {
            get => toothExtractionNeeded; 
            set
            {
                if (value)
                {
                    toothExtractionNeeded = value;
                    DentalServices += ToothExtraction;
                }

            }
        }

        public bool RegularCheckUp { get => regularCheckUp; set => regularCheckUp = value; }

        public string CavityFilling()
        {
            return "Cavity Filling";
        }

        public string Cleaning()
        {
            return "Dental Cleaning";
        }

        //Abstract method that will be overridden in respective derived classes
        public abstract string OtherService();

        public string RoutineCheckUp()
        {
            return "Routine Check Up";
        }


        public string ToothExtraction()
        {
            return "Tooth Extraction";
        }

        private void SetupDentalServiesDelegate()
        {
            this.dentalServices += RoutineCheckUp;
        }

      

        public override string ToString()
        {
            string result = "";
            foreach (DentalServicesDelegate service in this.dentalServices.GetInvocationList())
            {
                result += service() + "\n";
            }

            return string.Format(result);
        }

        //We use this to get secure credit card information
        private string concealedCreditCardNumber()
        {
            long ccNumber = long.Parse(CreditCardNumber);
            string cc = String.Format("{0:0000 0000 0000 0000}", ccNumber);
            char[] creditCardCharArray = cc.ToCharArray();
            for (int i = 5; i < 14; i++)
            {
                if (!creditCardCharArray[i].Equals(' '))
                {
                    creditCardCharArray[i] = 'X';
                }
            }
            return new String(creditCardCharArray);
        }
    }
}
