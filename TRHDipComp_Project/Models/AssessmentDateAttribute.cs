using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace TRHDipComp_Project.Models
{
    public class AssessmentDateAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object Date, ValidationContext validationContext)
        {
            AssessmentResult result = (AssessmentResult)validationContext.ObjectInstance;

            string msg = "";
            // Calculate days since assessment
            TimeSpan daysSinceAssessment = DateTime.Now - result.AssessmentDate;

            if (daysSinceAssessment.TotalDays > 180)
            {
                msg = $"Assessment date: {result.AssessmentDate.ToShortDateString()} is older than six months";

            } else if (daysSinceAssessment.TotalDays < 0)
            {
                msg = $"Assessment date: {result.AssessmentDate.ToShortDateString()} is in the future";
            }
            else
            {
                return ValidationResult.Success;
            }
                
            return new ValidationResult(msg);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-assessment-date", "Assessment date is older than six months");
        }
    }
}