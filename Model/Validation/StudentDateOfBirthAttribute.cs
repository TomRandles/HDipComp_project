using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Models.Validation
{
    public class StudentDateOfBirthAttribute : ValidationAttribute, IClientModelValidator
    {
        #region is_valid
        // Validation rule - student must be between 18 and 16
        protected override ValidationResult IsValid(object DateOfBirth, ValidationContext validationContext)
        {
            Student student = (Student)validationContext.ObjectInstance;

            // Calculate student's age in days. 
            TimeSpan ageInDays = DateTime.Now - student.DateOfBirth;

            // Student must be 18 or over and 60 or under
            if ((ageInDays.Days >= (365 * 18)) &&
                (ageInDays.Days <= (365 * 60))
               )
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Must be between 18 and 60 years of age");
        }
        #endregion

        #region add_validation
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-date-of-birth", "Must be between 18 and and 60 years");
        }
        #endregion
    }
}