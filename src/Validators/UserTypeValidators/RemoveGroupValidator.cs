using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Validators.UserTypeValidators
{
    public class RemoveGroupValidator : AbstractValidator<RemoveGroup>
    {
        public RemoveGroupValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.GroupId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserTypeId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}