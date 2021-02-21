using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.UserService.Requests;

namespace Identity.Api.Validators.UserValidators
{
    public class UpdateValidator : AbstractValidator<Update>
    {
        public UpdateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.LoginPrefix)
                .NotEmpty();

            RuleFor(c => c.FirstName)
                .NotEmpty();

            RuleFor(c => c.LastName)
                .NotEmpty();

            RuleFor(c => c.Email)
                .NotEmpty();
        }
    }
}