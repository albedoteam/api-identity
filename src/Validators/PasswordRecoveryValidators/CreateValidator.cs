using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.PasswordRecoveryService.Requests;

namespace Identity.Api.Validators.PasswordRecoveryValidators
{
    public class CreateValidator: AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
            
            RuleFor(c => c.UserEmail)
                .NotEmpty();
        }
    }
}