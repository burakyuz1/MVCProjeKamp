using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.FluentValidation
{
    public class ContantValidator : AbstractValidator<Contact>
    {
        public ContantValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail can not be empty");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message can not be empty");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message can not be empty");
        }
    }
}