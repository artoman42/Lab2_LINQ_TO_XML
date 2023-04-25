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
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Id)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Client Id should be a number between 0 and 9.");
            RuleFor(client => client.FullName)
                .NotEmpty().WithMessage("Client Full Name must not be empty.");
            RuleFor(client => client.Adress)
                .NotEmpty().WithMessage("Client Adress must not be empty.");
            RuleFor(client => client.Phone)
                .NotEmpty().WithMessage("Client Phone must not be empty.")
                .Matches("^0\\d{9}$").WithMessage("Client Prhone must have 10 digits and starts with 0");
            RuleFor(client => client.Category)
                .IsInEnum().WithMessage("Client Category must be a valid enum value.");
        }
    }
}
