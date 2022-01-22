using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assignment5
{
    //We create this class to validate CreditCard Text Field.
    //We will bind this class to the respective text field in XAML
    class CreditCardRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long cardValue = 0;
            if (!long.TryParse(value.ToString(), out cardValue))
            {
                return new ValidationResult(false, "Wrong data. Enter a valid 16 digit credit card number.");
            }

            if(cardValue.ToString().Length != 16)
            {
                return new ValidationResult(false, "Enter a valid 16 digit credit card number.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
