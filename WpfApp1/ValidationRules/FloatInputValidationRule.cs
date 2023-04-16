using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.ValidationRules
{
    class FloatInputValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                float.Parse((string)value);
            }
            catch
            {
                return new ValidationResult(false,$"Неверный формат ввода для {(string)value}");
            }
            return ValidationResult.ValidResult;
        }
    }
}
