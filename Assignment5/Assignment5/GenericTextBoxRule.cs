using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assignment5
{
    //We create this class to validate Generic String Text Field.
    //We will bind this class to the respective text field in XAML
    class GenericTextBoxRule : ValidationRule
    {
        int maxlength;

        public int Maxlength { get => maxlength; set => maxlength = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString().Length == 0)
            {
                return new ValidationResult(false, "The field cannot be empty");
            }

            if(value.ToString().Length > maxlength)
            {
                return new ValidationResult(false, $"Length should not exceed {maxlength}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
