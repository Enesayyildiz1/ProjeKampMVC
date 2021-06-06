using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(p => p.WriterId).NotEmpty();
            RuleFor(p => p.Writer).NotEmpty();
            RuleFor(p => p.HeadingStatus).NotEmpty();
            RuleFor(p => p.HeadingName).NotEmpty();
            RuleFor(p => p.HeadingId).NotEmpty();
        }
    }
}
