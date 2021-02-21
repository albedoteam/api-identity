using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Validators.UserTypeValidators
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