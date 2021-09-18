namespace Identity.Api.Validators.GroupValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.GroupService.Requests;

    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.DisplayName)
                .NotEmpty();

            RuleFor(c => c.Description)
                .NotEmpty();
        }
    }
}