using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DollarConverter.Client
{
    internal class DollarValidator : ValidationRule
    {
        public override ValidationResult Validate(object objectValue, CultureInfo cultureInfo)
        {
            var culture = cultureInfo.Clone() as CultureInfo;
            culture.NumberFormat.NumberDecimalSeparator = ",";

            decimal value;
            if (!decimal.TryParse(
                objectValue.ToString().Replace(" ", string.Empty),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                culture,
                out value))
            {
                return new ValidationResult(false, "Input is not a number - use format: XXX,XX");
            }
            
            if (value < 0)
            {
                return new ValidationResult(false, "Value can't be negative");
            }
            
            if (value > 999999999.99m)
            {
                return new ValidationResult(false, "Value can't be greater than 999 999 999,99");
            }
            
            var roundedValue = Math.Round(value, 2);
            if (roundedValue != value)
            {
                return new ValidationResult(false, "Decimal fraction can't have more than 2 digits");
            }

            return new ValidationResult(true, null);
        }
    }
}
