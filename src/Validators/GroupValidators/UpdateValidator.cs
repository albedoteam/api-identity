namespace Identity.Api.Validators.GroupValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.GroupService.Requests;

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

            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.DisplayName)
                .NotEmpty();

            RuleFor(c => c.Description)
                .NotEmpty();
        }
    }
}