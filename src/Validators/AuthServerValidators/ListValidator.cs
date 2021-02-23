using FluentValidation;
using Identity.Api.Services.AuthServerService.Requests;

namespace Identity.Api.Validators.AuthServerValidators
{
    public class ListValidator : AbstractValidator<List>
    {
        public ListValidator()
        {
            RuleFor(c => c.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}