namespace Identity.Api.Validators.UserValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserService.Requests;

    public class ExpirePasswordValidator : AbstractValidator<ExpirePassword>
    {
        public ExpirePasswordValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Reason)
                .NotEmpty();
        }
    }
}