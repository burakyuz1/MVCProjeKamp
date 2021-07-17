using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.FluentValidation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Heading name can not be empty");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Please choose a category");
        }
    }
}