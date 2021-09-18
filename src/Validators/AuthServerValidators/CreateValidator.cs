namespace Identity.Api.Validators.AuthServerValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.AuthServerService.Requests;

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