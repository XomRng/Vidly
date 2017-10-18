using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace Vidly.Models
{
    public class StrongPassword: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isUpper=false, isLower=false, isSymbol=false, isNumber=false, isLetter=false;

            string pass = (string)value;
            if (pass.Length < 10)
            {
                return new ValidationResult("Hasło musi mieć więcej niż 10 znaków");
            }
            
                foreach (char c in pass)
                {
                    if (char.IsUpper(c))
                        isUpper = true;
                    if (char.IsLower(c))
                        isLower = true;
                    if (char.IsSymbol(c))
                        isSymbol = true;
                    if (char.IsNumber(c))
                        isNumber = true;
                    if (char.IsLetter(c))
                        isLetter = true;
                }

                if (isUpper == false || isLower == false)
                {
                    return new ValidationResult("Hasło musi mieć duże i małe znaki");
                }
                if(isSymbol == false)
                {
                    return new ValidationResult("W haśle musi być przynajmniej jeden znak specjalny.");
                }
                if (isNumber == false)
                {
                    return new ValidationResult("W haśle musi być przynajmniej jedna cyfra");
                }
                if (isLetter == false)
                {
                    return new ValidationResult("W haśle musi być przynajmniej jedna litera");
                }

            return ValidationResult.Success;
            
        }
    }
}