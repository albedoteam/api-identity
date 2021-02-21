using System.Text.RegularExpressions;
using FluentValidation;
using Identity.Api.Services.GroupService.Requests;

namespace Identity.Api.Validators.GroupValidators
{
    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.SuffixName)
                .NotEmpty();

            RuleFor(c => c.SuffixDescription)
                .NotEmpty();
        }
    }
}