﻿namespace Identity.Api.Validators.UserTypeValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.UserTypeService.Requests;

    public class RemoveGroupValidator : AbstractValidator<RemoveGroup>
    {
        public RemoveGroupValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.GroupId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.UserTypeId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}