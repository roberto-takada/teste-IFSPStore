using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Services.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Por favor informe o nome")
                .NotNull().WithMessage("Por favor informe o nome")
                .Length(100).WithMessage("Nome não pode possuir mais que 100 caracteres");

            RuleFor(c => c.Estado).NotEmpty().WithMessage("Por favor infome o nome")
                .NotNull().WithMessage("Por favor infome o nome")
                .Length(2).WithMessage("O Estado pode apenas receber Siglas");
        }
    }
}
