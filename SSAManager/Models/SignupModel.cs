using Nancy.Validation;
using System.Collections.Generic;

namespace SSAManager
{
    using System;
    using Nancy.Validation.FluentValidation;
    using FluentValidation;

    public class SignupModel
    {
        public string Email { get; set; }
        public string Secret { get; set; }
        public string ComfirmSecret { get; set; }
        public IEnumerable<ModelValidationError> Errors { get; set; }

    }

    public class SignupValidator : AbstractValidator<SignupModel>
    {
        public SignupValidator()
        {
            RuleFor(signup => signup.Email).NotEmpty();
            RuleFor(signup => signup.Email).EmailAddress();
            RuleFor(signup => signup.Secret).NotEmpty();
            //RuleFor(product => product.Name).Matches("[A-Z]*");


            //RuleFor(product => product.Price).ExclusiveBetween(10, 15);
            //RuleFor(product => product.Price).InclusiveBetween(10, 15);
            //RuleFor(product => product.Price).Equal(5);
        }
    }
}

