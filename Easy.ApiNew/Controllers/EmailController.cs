using Easy.Services.DTOs.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class EmailController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("enviar")]
    public ActionResult EnviarEmail([FromBody] EmailDto emailDto)
    {
        try
        {
            using (SmtpClient smtp = new())
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

                    smtp.Send(msg);
                }
            }

            return Ok("Email Enviado");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao enviar e-mail: {ex.Message}");
        }
    }

}