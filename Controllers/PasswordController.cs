using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using virtual_ex.ControllerServices;
using virtual_ex.MiddleWare;
using virtual_ex.Models;
using virtual_ex.RequestForms;

namespace LoginRegProject.Controllers
{

 
    [Route("api/password/")]
    [ApiController]
    public class PasswordController(
            UserManager<UserModel> _userManager,
            IConfiguration _configuration,
            IEmailService _emailService,
            IJwtTokenService _jwtTokenService
        ) : ControllerBase
    {

        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly IConfiguration configuration = _configuration;
        private readonly IEmailService emailService = _emailService;
        private readonly IJwtTokenService jwtTokenService = _jwtTokenService;




        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetForm requestPasswordResetForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel? user = await userManager.FindByEmailAsync(requestPasswordResetForm.Email);

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





                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, protocol: HttpContext.Request.Scheme);

                var param = new Dictionary<string, string>
                {
                    {"token", token },
                    {"email", user.Email }
                };

                var callBack = QueryHelpers.AddQueryString
                    (
                    "https://localhost:7286/api/PasswordController/password-reset",
                    param!
                    );


                bool message = await emailService.SendMail
                    (
                        "Password Reset",
                        [user.Email],
                        $"<h1> <a href= {callBack}>Click here to reset your password </a> </h1>"
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







        [HttpPost("password-reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordForm resetPasswordForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                var user = await userManager.FindByEmailAsync(resetPasswordForm.Email);
                if (user == null || user.LockoutEnabled == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "This user could not be found or has been deactivated" }
                        );
                }

                var _userRoles = await userManager.GetRolesAsync(user);
                if (_userRoles.Contains("SuperAdmin") || _userRoles.Contains("Admin"))
                {
                    return StatusCode
                        (
                            StatusCodes.Status403Forbidden,
                            new { message = "This operation is not allowed" }
                        );
                }



                var confirmResult = await userManager.ResetPasswordAsync(user, resetPasswordForm.Token, resetPasswordForm.New_Password);
                if (!confirmResult.Succeeded)
                {
                    return StatusCode
                       (
                           StatusCodes.Status400BadRequest,
                           new { message = "Bad Request" }
                       );
                }


                return StatusCode
                       (
                           StatusCodes.Status200OK,
                           new { message = "Password reset successful" }
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







        [Authorize(Roles = "Admin,Seller,Agent,Buyer")]
        [HttpPost("password-change")]
        [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordForm changePasswordForm)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                UserModel user = HttpContext.Items["User"] as UserModel;

                bool isPasswordCorrect = await userManager.CheckPasswordAsync(user!, changePasswordForm.OldPassword);
                if (!isPasswordCorrect)
                {
                    return StatusCode
                        (
                            StatusCodes.Status401Unauthorized,
                            new { message = "Old Password is not correct" }
                        );
                }

                var passwordRequest = await userManager.ChangePasswordAsync(user, changePasswordForm.OldPassword, changePasswordForm.NewPassword);

                if (!passwordRequest.Succeeded)
                {
                    return StatusCode
                        (
                            StatusCodes.Status500InternalServerError,
                            new { message = "Could not complete request, Something went wrong on our side" }
                        );
                }


                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Password changed successfully" }
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


    }
}
