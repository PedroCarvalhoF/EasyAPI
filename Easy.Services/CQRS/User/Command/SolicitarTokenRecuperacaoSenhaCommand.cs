﻿using Easy.Domain.Entities.User;
using Easy.Services.CQRS.User.Notification;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command;

public class SolicitarTokenRecuperacaoSenhaCommand : BaseCommands<UserDtoSolicitarTokenResult>
{
    public UserDtoRequestEmail Email { get; private set; }
    public SolicitarTokenRecuperacaoSenhaCommand(UserDtoRequestEmail email)
    {
        Email = email;
    }

    public class SolicitarTokenRecuperacaoSenhaCommandHandler(UserManager<UserEntity> _userManager, IMediator _mediator) : IRequestHandler<SolicitarTokenRecuperacaoSenhaCommand, RequestResult<UserDtoSolicitarTokenResult>>
    {
        public async Task<RequestResult<UserDtoSolicitarTokenResult>> Handle(SolicitarTokenRecuperacaoSenhaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(request.Email.Email);
                if (user == null)
                    return RequestResult<UserDtoSolicitarTokenResult>.BadRequest("Usuário não localizado");

                var token = GerarToken();

                // Salvar o token na tabela AspNetUserTokens
                await _userManager.SetAuthenticationTokenAsync(user, "Default", "PasswordResetToken", token);

                var notificacao = new UserEnviarTokenRecupecaoSenhaNotificacao(token, request.Email.Email);

                await _mediator.Publish(notificacao);

                var recuperacaoSenhaResult = new UserDtoSolicitarTokenResult();

                return RequestResult<UserDtoSolicitarTokenResult>.Ok(recuperacaoSenhaResult);
            }
            catch (Exception ex)
            {

                return RequestResult<UserDtoSolicitarTokenResult>.BadRequest(ex.Message);
            }
        }

        private string GerarToken()
        {

            var token = Guid.NewGuid().ToString().Replace("-", string.Empty).Trim();
            var token6Char = token.Substring(0, 6);

            return token6Char;
        }
    }
}

