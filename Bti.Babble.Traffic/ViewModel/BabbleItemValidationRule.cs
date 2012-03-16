using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bti.Babble.Traffic
{
    public class BabbleItemValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            BabbleItemViewModel evt = (value as BindingGroup).Items[0] as BabbleItemViewModel;
            if (evt.Type.Name.Length == 0)
            {
                return new ValidationResult(false,
                    "Select a type for this babble event");
            }

            return ValidationResult.ValidResult;
        }
    }
}
