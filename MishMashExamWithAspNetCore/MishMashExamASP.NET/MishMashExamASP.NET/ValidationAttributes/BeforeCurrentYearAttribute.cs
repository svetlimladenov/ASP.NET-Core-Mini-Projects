﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MishMashExamASP.NET.ValidationAttributes
{
    public class BeforeCurrentYearAttribute : ValidationAttribute
    {
        private readonly int afterYear;

        public BeforeCurrentYearAttribute(int afterYear)
        {
            this.afterYear = afterYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is int))
            {
                return new ValidationResult("Invalid" + validationContext.DisplayName);
            }

            var valueAsInt = (int) value;
            if (valueAsInt > DateTime.UtcNow.Year)
            {
                return new ValidationResult(validationContext.DisplayName + " is after " + DateTime.UtcNow.Year);
            }
                
            if (this.afterYear > valueAsInt)
            {
                return new ValidationResult(validationContext.DisplayName + " is before " + this.afterYear);
            }

            return ValidationResult.Success;
        }
    }
}
