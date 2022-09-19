namespace Sat.Recruitment.Api.Models.ViewModels
{
    using System;
    using FluentValidation;

    public class UserCreateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }

        internal class Validator : AbstractValidator<UserCreateModel>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.Phone).NotEmpty();
                RuleFor(x => x.UserType).IsInEnum();
                RuleFor(x => x.Money > 0).NotNull();
            }
        }
    }
}
