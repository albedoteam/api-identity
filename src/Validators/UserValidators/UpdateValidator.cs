namespace Identity.Api.Validators.UserValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserService.Requests;

    public class UpdateValidator : AbstractValidator<Update>
    {
        public UpdateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Username)
                .NotEmpty();

            RuleFor(c => c.FirstName)
                .NotEmpty();

            RuleFor(c => c.LastName)
                .NotEmpty();

            RuleFor(c => c.Email)
                .NotEmpty();
        }
    }
}