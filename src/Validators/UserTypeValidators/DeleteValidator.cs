using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Validators.UserTypeValidators
{
    public class DeleteValidator : AbstractValidator<Delete>
    {
        public DeleteValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}