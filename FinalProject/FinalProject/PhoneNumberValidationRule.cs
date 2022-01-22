using System.Globalization;
using System.Windows.Controls;

namespace FinalProject
{
    //We create this class to validate PhoneNumber Text Field.
    //We will bind this class to the respective text field in XAML
    class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long phoneNumberValue = 0;
            if (!long.TryParse(value.ToString(), out phoneNumberValue))
            {
                return new ValidationResult(false, "Wrong data. Enter a valid 10  digit phone number.");
            }

            if (phoneNumberValue.ToString().Length != 10)
            {
                return new ValidationResult(false, "Enter a valid 10 digit phone number.");
            }

            return ValidationResult.ValidResult;
        }
    }
    
    
}
