using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // daje nam dostęp do obiektu sprawdzanego, w tym wypadku Customer
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;

            if(customer.Birthdate == null)
                return new ValidationResult("Data urodzenia jest wymagana!");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Klient musi mieć przynajmniej 18 lat, a ma " + age + " lat.");
        }
    }
}