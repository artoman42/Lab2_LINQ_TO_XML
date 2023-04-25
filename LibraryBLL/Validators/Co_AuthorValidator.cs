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
    public class Co_AuthorValidator : AbstractValidator<Co_Author>
    {
        public Co_AuthorValidator() {
            RuleFor(coAuthor => coAuthor.Id).Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Book Id should be a number between 0 and 9"); 
            RuleFor(coAuthor => coAuthor.BookId).Must(bookId => Regex.IsMatch(bookId.ToString(), @"^[0-9]$"))
                .WithMessage("Book Id should be a number between 0 and 9");
            RuleFor(coAuthor => coAuthor.AuthorId)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Author Id should be a number between 0 and 9");

        }
    }
}
