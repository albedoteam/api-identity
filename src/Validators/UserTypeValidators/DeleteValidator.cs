namespace Identity.Api.Validators.UserTypeValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserTypeService.Requests;

    public class DeleteValidator : AbstractValidator<Delete>
    {
        public DeleteValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}