using CleanAPI.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAPI.Infrastructure.Validators
{
    public class PostValidator:AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula")
                .Length(10, 500)
                .WithMessage("La longitud del la descripcion debe estar entre 10 y 500 caracteres");

            RuleFor(post => post.Date)
                .NotNull()
                .WithMessage("Se requiere una fecha")
                .LessThan(Convert.ToDateTime("2021-01-01"))
                .WithMessage("La fecha debe ser menor a yyyy-MM-dd 2021-01-01");
        }
    }
}
