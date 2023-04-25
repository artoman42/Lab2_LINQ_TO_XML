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
    public class SubscriptionValidator : AbstractValidator<Subscription>
    {
        public SubscriptionValidator() {
            RuleFor(subscription => subscription.Id)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Subscription Id should be a number between 0 and 9");
            RuleFor(subscription => subscription.ClientId)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("ClientId Id should be a number between 0 and 9"); 
            RuleFor(subscription => subscription.BookId)
                .Must(id => Regex.IsMatch(id.ToString(), @"^[0-9]$"))
                .WithMessage("Book Id should be a number between 0 and 9");
            RuleFor(subscription => subscription.DateOfIssue).NotEmpty();
            RuleFor(subscription => subscription.ExpectedReturnDate).NotEmpty();
        }
    }
}
