using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p => p.WriterImage).NotEmpty();
            RuleFor(p => p.WriterName).MinimumLength(3);
            RuleFor(p => p.WriterPassword).NotEmpty();
            RuleFor(p => p.WriterSurname).NotEmpty();
            RuleFor(p => p.WriterAbout).NotEmpty();

        }
    }
}
