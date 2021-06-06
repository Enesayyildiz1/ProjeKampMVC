using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public  class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(p => p.MessageContent).NotEmpty();
            RuleFor(p => p.Receiver).NotEmpty();
            RuleFor(p => p.Sender).NotEmpty();
            RuleFor(p => p.Subject).NotEmpty();
        
        }
    }
}
