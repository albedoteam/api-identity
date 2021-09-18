﻿namespace Identity.Api.Validators.UserValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserService.Requests;

    public class AddGroupValidator : AbstractValidator<AddGroup>
    {
        public AddGroupValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.GroupId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}