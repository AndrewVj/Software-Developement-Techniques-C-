using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //Dummy Class to create dummy objects to check errors and bind in the data grid
    public class ValidatingFields
    {
        private string creditCardNumber = "";
        private string phoneNumber = "";
        private int age;
        private string name = "";

        public ValidatingFields()
        {

        }


        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
    }

}
