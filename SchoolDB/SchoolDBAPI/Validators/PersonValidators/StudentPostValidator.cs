using FluentValidation;
using SchoolDBAPI.DTO;
using SchoolDBAPI.Library.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.Validators.PersonValidators
{
    public class StudentPostValidator : AbstractValidator<StudentPostDTO>
    {
        public StudentPostValidator()
        {
            RuleFor(s => s.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 30);
            RuleFor(s => s.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(2, 30);
            // Validate? RuleFor(s => s.BirthDate)
            RuleFor(s => s.Grade)
                .InclusiveBetween(7, 12);
        }
    }
}
