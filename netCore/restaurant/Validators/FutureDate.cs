using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace restaurant.Validators
{
     public class FutureDateAttribute : ValidationAttribute
    {
       
        public FutureDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            System.Console.WriteLine("--------I am here-----------*********");
            if(dt.Date > DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }
    }
  
}