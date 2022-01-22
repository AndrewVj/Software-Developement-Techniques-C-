using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assignment5
{
    //We create this class to validate Search Text Field.
    //We will bind this class to the respective text field in XAML
    class SearchYearRule : ValidationRule
    {
        int min;
        int max;

        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numVal = 0;
            if (!int.TryParse(value.ToString(), out numVal))
            {
                return new ValidationResult(false, "Wrong Data. Enter a year between 1950 and 2021.");
            }

            if (numVal < min || numVal > max)
            {
                return new ValidationResult(false, "Out of range. Enter a year between 1950 and 2021.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
