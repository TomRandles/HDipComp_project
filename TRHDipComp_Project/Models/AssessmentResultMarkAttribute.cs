﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TRHDipComp_Project.Models
{
    public class AssessmentResultMarkAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object AssessmentResult, ValidationContext validationContext)
        {
            // Get current Assessment Result object 
            AssessmentResult assessmentResult = (AssessmentResult)validationContext.ObjectInstance;

            // Get DB context 
            var _db = (CollegeDbContext)validationContext
                         .GetService(typeof(CollegeDbContext));

            // Get the assessment for this assessment result
            IList<Assessment> assessments = _db.Assessments.AsNoTracking().ToList();

            Assessment assessment = assessments.Where(a => a.AssessmentID == assessmentResult.AssessmentID)
                                               .Select(a => a).FirstOrDefault();
            
            // Check that the assessment result mark is less than the assessment total mark
            if (assessmentResult.AssessmentResultMark <= assessment.AssessmentTotalMark)
            {
                return ValidationResult.Success;
            }
            string valReturn = $"Assessment result {assessmentResult.AssessmentResultMark} must be less than or equal to {assessment.AssessmentTotalMark}";
            return new ValidationResult(valReturn);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-assessment-result-mark", "Assessment result must be less than or equal to assessment total mark");
        }
    }
}