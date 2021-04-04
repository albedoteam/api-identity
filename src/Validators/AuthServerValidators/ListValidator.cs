namespace Identity.Api.Validators.AuthServerValidators
{
    using FluentValidation;
    using Services.AuthServerService.Requests;

    public class ListValidator : AbstractValidator<List>
    {
        public ListValidator()
        {
            RuleFor(c => c.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}