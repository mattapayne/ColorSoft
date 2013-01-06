using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ColorSoft.Web.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailValidationAttribute : RegularExpressionAttribute
    {
        private const string EmailPattern = @"^\w+([-+.]*[\w-]+)*@(\w+([-.]?\w+)){1,}\.\w{2,4}$";

        static EmailValidationAttribute()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (EmailValidationAttribute),
                                                                  typeof (RegularExpressionAttributeAdapter));
        }

        public EmailValidationAttribute()
            : base(EmailPattern)
        {
        }
    }
}