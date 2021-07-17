using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Name can contain maximum 20 characters.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Name can contain minimum 3 characters.");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Surname can not be empty");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage(" name can contain maximum 20 characters.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage(" name can contain minimum 2 characters.");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail can not be empty");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Title can not be empty");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Writer can not be empty");
        }
    }
}