using CleanAPI.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .WithMessage(x=>$"{x.Password}: Property cannot be null.");

        }
    }
}
