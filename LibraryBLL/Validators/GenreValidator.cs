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
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator() {
            RuleFor(genre => genre.Id)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Book Id should be a number between 0 and 9");
            RuleFor(genre => genre.pGenre).IsInEnum().WithMessage("Invalid genre.");

        }
    }
}
