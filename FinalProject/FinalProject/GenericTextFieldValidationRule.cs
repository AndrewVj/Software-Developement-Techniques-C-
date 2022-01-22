using System.Globalization;
using System.Windows.Controls;

namespace FinalProject
{
    //We create this class to validate Generic Text Field.
    //We will bind this class to the respective text field in XAML
    class GenericTextFieldValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Wrong data. Field should not be empty.");
            }

            if ((value.ToString().Length < Min) || (value.ToString().Length > Max))
            {
                return new ValidationResult(false, $"The Field should have {Min}-{Max} characters.");
            }

            return ValidationResult.ValidResult;
        }
    }

}
