using System;
using System.ComponentModel.DataAnnotations;

namespace restaurant.Validators
{
    public class FutureDate : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "You can't be from the future";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            //alter this as needed. I am doing the date comparison if the value is not null

            if (dateValue.Date > DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}