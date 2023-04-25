using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using Library;
namespace LibraryBLL.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.Id)
                .NotEmpty().WithMessage("Author Id is required.")
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Author Id should be a number between 0 and 9, including 9.");

            RuleFor(author => author.Name)
                .NotEmpty().WithMessage("Author Name is required.")
                .MaximumLength(50).WithMessage("Author Name should not exceed 50 characters.");
        }
    }
}
