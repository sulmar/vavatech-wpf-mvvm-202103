using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MetalDesignWpfClient.ValidationRules
{
    public class NumericRangeValidationRule : ValidationRule
    {
        public int? Minimum { get; set; }
        public int? Maximum { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (int.TryParse(value.ToString(), out int number))
            {

                if ( (Minimum.HasValue && number < Minimum) || (Maximum.HasValue && number > Maximum))
                {
                    return new ValidationResult(false, "Liczba poza zakresem");
                }

                return ValidationResult.ValidResult;

            }
            else
            {
                return new ValidationResult(false, "Liczba w złym formacie");
            }
        }
    }
}
