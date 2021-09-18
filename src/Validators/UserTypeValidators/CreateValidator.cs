namespace Identity.Api.Validators.UserTypeValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserTypeService.Requests;

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