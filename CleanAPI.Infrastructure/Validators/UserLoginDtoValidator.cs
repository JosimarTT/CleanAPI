using CleanAPI.Core.DTOs;
using FluentValidation;

namespace CleanAPI.Infrastructure.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.UserName)
                    .NotNull()
                    .WithMessage(x => $"{x.UserName}: Property cannot be null.");

            RuleFor(x => x.Password)
                    .NotNull()
                    .WithMessage(x => $"{x.Password}: Property cannot be null.");

        }
    }
}
