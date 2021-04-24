using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
     public static class ValidationTool
    {
        public static void Validate(IValidator validator,object T)
        {
           
            var result = validator.Validate(T);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
                // Console.WriteLine(result.Errors.FirstOrDefault().ToString());

            }
        }
    }
}
