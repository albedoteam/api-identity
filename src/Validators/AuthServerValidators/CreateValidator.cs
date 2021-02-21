using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.AuthServerService.Requests;

namespace Identity.Api.Validators.AuthServerValidators
{
    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}