﻿using Easy.Services.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.User.Command
{
    public class AlterarSenhaUserCommand : IRequest<RequestResult>
    {
        public AlterarSenhaUserCommand(Guid idUser, string senhaAntiga, string novaSenha, string confirmPassword)
        {
            IdUser = idUser;
            SenhaAntiga = senhaAntiga;
            NovaSenha = novaSenha;
            ConfirmPassword = confirmPassword;
        }

        [Required]
        [Display(Name = "Id do Usuario")]
        public Guid IdUser { get; private set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Antiga.")]
        public string SenhaAntiga { get; private set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha.")]
        public string NovaSenha { get; private set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Nova Senha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não combinão.")]
        public string ConfirmPassword { get; private set; }
    }
}
