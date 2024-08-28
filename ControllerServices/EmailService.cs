using MailKit.Net.Smtp;
using MimeKit;

namespace virtual_ex.ControllerServices
{
    public interface IEmailService
    {
        Task<bool> SendMail(string subject, IEnumerable<string> to, string body);
    }



    public class EmailService(IConfiguration _configuration): IEmailService
    {
        private readonly IConfiguration configuration = _configuration;


        public async Task<bool> SendMail(string subject, IEnumerable<string> to, string body)
        {


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                    configuration["EmailConfiguration:Username"],
                    configuration["EmailConfiguration:From"]
                ));

            foreach (var emailTos in to)
            {
                message.To.Add(new MailboxAddress("", emailTos));
            }

            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync
                    (
                        configuration["EmailConfiguration:SmtpServer"],
                        Convert.ToInt16(configuration["EmailConfiguration:Port"]),
                        MailKit.Security.SecureSocketOptions.StartTls

                    );

                await client.AuthenticateAsync
                    (
                        configuration["EmailConfiguration:From"],
                        configuration["EmailConfiguration:Password"]
                    );

                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.Write("DONE");

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
