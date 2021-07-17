using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer.FluentValidation
{
    public class MessageValidator :AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("subject can not be empty");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("content can not be empty");
            RuleFor(x => x.MessageReciever).NotEmpty().WithMessage("mail can not be empty");

        }
    }
}