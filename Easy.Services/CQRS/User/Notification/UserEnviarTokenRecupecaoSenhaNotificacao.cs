using Easy.Services.DTOs.Email;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Easy.Services.CQRS.User.Notification;

public class UserEnviarTokenRecupecaoSenhaNotificacao : INotification
{
    public string Token { get; private set; }
    public string Email { get; private set; }

    public UserEnviarTokenRecupecaoSenhaNotificacao(string token, string email)
    {
        Token = token;
        Email = email;
    }

    public override string ToString()
    {
        return $"Token criado {Token}";
    }

    public class UserEnviarTokenRecupecaoSenhaNotificacaoHandler : INotificationHandler<UserEnviarTokenRecupecaoSenhaNotificacao>
    {
        private readonly ILogger<UserCreateEmailHandler> _logger;

        public UserEnviarTokenRecupecaoSenhaNotificacaoHandler(ILogger<UserCreateEmailHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserEnviarTokenRecupecaoSenhaNotificacao notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(notification.ToString());

            var emailDto = new EmailDto(notification.Email, "Token", $"Código para recuperação recuperar senha: {notification}");

            await EnviarEmail(emailDto);
        }

        private async Task EnviarEmail(EmailDto emailDto)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587; // Porta correta para TLS
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("easysistemsolucoes@gmail.com", "pefs cxjt cola xjif");

                    using (MailMessage msg = new MailMessage())
                    {
                        msg.From = new MailAddress("easysistemsolucoes@gmail.com");
                        msg.To.Add(new MailAddress(emailDto.EmailDestinatario));
                        msg.Subject = emailDto.Assunto;
                        msg.Body = emailDto.Email;

                       await smtp.SendMailAsync(msg);
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }



}
