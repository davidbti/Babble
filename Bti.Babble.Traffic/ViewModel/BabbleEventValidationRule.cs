using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bti.Babble.Traffic
{
    public class BabbleEventValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            BabbleEventViewModel evt = (value as BindingGroup).Items[0] as BabbleEventViewModel;
            if (evt.Type.Name.Length == 0)
            {
                return new ValidationResult(false,
                    "Select a type for this babble event");
            }

            if (evt.Name.Length == 0)
            {
                return new ValidationResult(false,
                    "Give this babble event a name");
            }

            return ValidationResult.ValidResult;
        }
    }
}
