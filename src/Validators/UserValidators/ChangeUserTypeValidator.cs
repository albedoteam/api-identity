using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.UserService.Requests;

namespace Identity.Api.Validators.UserValidators
{
    public class ChangeUserTypeValidator : AbstractValidator<ChangeUserType>
    {
        public ChangeUserTypeValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserTypeId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}