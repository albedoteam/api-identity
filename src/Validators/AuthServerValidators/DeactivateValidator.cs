namespace Identity.Api.Validators.AuthServerValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.AuthServerService.Requests;

    public class DeactivateValidator : AbstractValidator<Deactivate>
    {
        public DeactivateValidator()
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