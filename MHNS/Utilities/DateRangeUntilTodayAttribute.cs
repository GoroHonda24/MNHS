using System;
using System.ComponentModel.DataAnnotations;

namespace MHNS.Utilities
{
    public class DateRangeUntilTodayAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;

        public DateRangeUntilTodayAttribute(string minDate)
        {
            _minDate = DateTime.Parse(minDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < _minDate || date > DateTime.Now)
                {
                    return new ValidationResult($"Birthdate must be between {_minDate.ToShortDateString()} and {DateTime.Now.ToShortDateString()}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
