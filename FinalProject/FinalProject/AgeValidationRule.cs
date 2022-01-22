using System.Globalization;
using System.Windows.Controls;

namespace FinalProject
{
    //We create this class to validate Age Text Field.
    //We will bind this class to the respective text field in XAML
    class AgeValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            uint ageValue = 0;
            if (!uint.TryParse(value.ToString(), out ageValue))
            {
                return new ValidationResult(false, "Wrong data. Enter a valid age.");
            }

            if ((ageValue < Min) || (ageValue > Max))
            {
                return new ValidationResult(false, $"Please enter an age in the range: {Min}-{Max}.");
            }

            return ValidationResult.ValidResult;
        }
    }
    
    
}
