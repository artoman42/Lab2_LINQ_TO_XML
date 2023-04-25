using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using FluentValidation;
using System.Text.RegularExpressions;

namespace LibraryBLL.Validators
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Id)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Book Id should be a number between 0 and 9");
            RuleFor(book => book.Name).NotEmpty().WithMessage("Book Name is required.");
            RuleFor(book => book.GenreId).Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Genre Id should be a number between 0 and 9");
            RuleFor(book => book.CollateralValue).GreaterThan(0).WithMessage("Collateral Value should be greater than 0.");
            RuleFor(book => book.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0.");
        }
    }
}
