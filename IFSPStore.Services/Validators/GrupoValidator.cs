using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Services.Validators
{
    public class GrupoValidator : AbstractValidator<Grupo>
    {
        public GrupoValidator() { 
            RuleFor(g => g.Nome)
                .NotEmpty().WithMessage("O nome não pode estar vazio")
                .NotNull().WithMessage("O nome não pode estar vazio")
                .Length(50).WithMessage("O nome não pode conter mais de 50 caracteres");
        }
    }
}
