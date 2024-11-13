using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Services.Validators
{
    public class UsuarioValidator:AbstractValidator<Usuario>
    {

        public UsuarioValidator() { 
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informar o nome")
                .NotNull().WithMessage("Por favor informar o nome");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor informar o email")
                .NotNull().WithMessage("Por favor informar o email");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Por favor digite a senha")
                .NotNull().WithMessage("Por favor digite a senha")
                .Matches(@"[A-Z]+").WithMessage("A senha deve ter pelo menos uma letra maiuscula")
                .Matches(@"[a-z]+").WithMessage("A senha deve ter pelo menos uma letra minuscula")
                .Matches(@"[0-9]+").WithMessage("A senha deve ter pelo menos um numero")
                .MinimumLength(8).WithMessage("A senha precisa ter pelo menos 8 digitos")
                .MaximumLength(16).WithMessage("A senha precisa ter no máximo 16 digitos");
        }

    }
}
