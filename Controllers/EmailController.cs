using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using virtual_ex.ControllerServices;
using virtual_ex.Models;
using virtual_ex.RequestForms;

namespace LoginRegProject.Controllers
{
    [Route("api/email/")]
    [ApiController]
    public class EmailController
        (
            UserManager<UserModel> _userManager,
            IConfiguration _configuration,
            IEmailService _emailService
        ) : ControllerBase
    {

        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly IConfiguration configuration = _configuration;
        private readonly IEmailService emailService = _emailService;



        [HttpPost("request-email-confirmation")]
        public async Task<IActionResult> RequestEmailConfirmation([FromBody] RequestEmailConfirmation requestEmailConfirmation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel? user = await userManager.FindByEmailAsync(requestEmailConfirmation.Email);

                if (user == null || user.LockoutEnabled == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "This user could not be found or has been deactivated" }
                        );
                }

                var _userRoles = await userManager.GetRolesAsync(user);
                if (_userRoles.Contains("Admin"))
                {
                    return StatusCode
                        (
                            StatusCodes.Status403Forbidden,
                            new { message = "This operation is not allowed" }
                        );
                }



                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var param = new Dictionary<string, string>
                {
                    {"token", token },
                    {"email", user.Email }
                };

                var callBack = QueryHelpers.AddQueryString
                    (
                    "https://localhost:7286/api/AuthenticationControllerr/email-confirmation",
                    param
                    );

                bool message = await emailService.SendMail
                    (
                        "Email Confirmation",
                        [user.Email],
                        $"<h1> <a href= {callBack}>Click here to confirm your email address </a> </h1>"
                    );

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Sent successfully" }
                    );

            }
            catch (Exception)
            {


                return StatusCode
                        (
                            StatusCodes.Status500InternalServerError,
                            new { message = "Could not complete request, Something went wrong on our side" }
                        );
            }
            
        }






        [HttpPost("send-mail")]
        public async Task<IActionResult> SendMail([FromBody] SendMailForm sendMailForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(
                    configuration["EmailConfiguration:Username"],
                    configuration["EmailConfiguration:From"]
                    ));


                foreach (var emailTos in sendMailForm.To)
                {
                    message.To.Add(new MailboxAddress("", emailTos));
                }

                message.Subject = sendMailForm.Subject;

                var bodyBuilder = new BodyBuilder { HtmlBody = sendMailForm.Body };
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

                    return Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return NoContent();
                }

            }
            catch (Exception)
            {

                return StatusCode
                        (
                            StatusCodes.Status500InternalServerError,
                            new { message = "Could not complete request, Something went wrong on our side" }
                        );
            }
            
        }
    }
}
