namespace Identity.Api.Validators.UserValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserService.Requests;

    public class ListValidator : AbstractValidator<List>
    {
        public ListValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}