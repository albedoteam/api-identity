namespace Identity.Api.Validators.UserValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserService.Requests;

    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserTypeId)
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