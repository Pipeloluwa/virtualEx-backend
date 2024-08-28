using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using virtual_ex.ControllerServices;
using virtual_ex.Models;
using virtual_ex.RequestForms;
using virtual_ex.ResponseForms;


namespace LoginRegProject.Controllers
{

    [Route("api/authentication/")]
    [ApiController]
    public class AuthenticationController
        (
        SignInManager<UserModel> _signInManager,
        UserManager<UserModel> _userManager,
        RoleManager<IdentityRole> _roleManager,
        IJwtTokenService _jwtTokenService
        ) : ControllerBase
    {



        private readonly SignInManager<UserModel> signInManager= _signInManager;
        private readonly UserManager<UserModel> userManager= _userManager;
        private readonly RoleManager<IdentityRole> roleManager= _roleManager;
        private readonly IJwtTokenService jwtTokenService= _jwtTokenService;








        [HttpGet("email-confirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string Email, [FromQuery] string Token)
        {
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Token))
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                var user = await userManager.FindByEmailAsync(Email);
                if (user == null || user.LockoutEnabled == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "This user could not be found or has been deactivated" }
                        );
                }

                if (user.EmailConfirmed == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status200OK,
                            new { message = "This email was already confirmed" }
                        );
                }

                var confirmResult = await userManager.ConfirmEmailAsync(user, Token);
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
                           new { message = "Email Address confirmed successfully" }
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








 
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginForm userLogin)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                UserModel ?user = await userManager.FindByEmailAsync(userLogin.Email_Or_Username);
                if (user == null)
                {
                    user = await userManager.FindByNameAsync(userLogin.Email_Or_Username);
                }

                if (user == null || user.LockoutEnabled == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "This user could not be found or has been deactivated" }
                        );
                }

                if (!user.EmailConfirmed)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new {message= "Your email has not been verified, verify first!"});
                }



                var loginResult = await signInManager.PasswordSignInAsync(
                    user, 
                    userLogin.Password, 
                    false,//Auto Remeber false, since we cookie base auth is not used
                    false // Since we defined 5 attempts in program.cs file but not for the new user as defined in program.cs, If the user still attempt to login on failure, do you want to log user out
                    );

                if (!loginResult.Succeeded)
                {
                    return Unauthorized("Please check your login details");
                }

                user.LastLogin = DateTime.Now;

                var jwtToken = await jwtTokenService.GenerateToken(user);

                var refreshToken = await jwtTokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiry= DateTime.UtcNow.AddHours(24);

                await userManager.UpdateAsync( user );

                return Ok
                    (
                        new
                        {
                            message= "User logged in Successfully",
                            token= jwtToken,
                            refresh_token= refreshToken,
                            user = new { user?.UserName }
                        }
                    );

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return BadRequest("Something went wrong, please try again later");
            }
        }








        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenResponse form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                var principal = await jwtTokenService.GetJWTPrincipal(form.JWTToken);

                var principalUserID = (principal?.Claims.FirstOrDefault(c => c.Type == "UserId"))?.Value;

                if (principalUserID.IsNullOrEmpty())
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "User details could not be extracted" });
                }


                var user = await userManager.FindByIdAsync(principalUserID!);


                if (user == null || user.LockoutEnabled == true)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "This user could not be found or has been deactivated" }
                        );
                }

                if (form.RefreshToken != user.RefreshToken || DateTime.UtcNow > user.RefreshTokenExpiry)
                {
                    return StatusCode
                        (
                            StatusCodes.Status400BadRequest,
                            new
                            {
                                message = "Please check if you provided the correct credentials"
                            }
                        );
                }

                var jwtToken = await jwtTokenService.GenerateToken(user);

                var refreshToken = await jwtTokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiry = DateTime.Now.AddHours(24);

                await userManager.UpdateAsync(user);

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new
                        {
                            message = "Token was refreshed Successfully, New Token Generated!",
                            token = jwtToken,
                            refresh_token = refreshToken,
                        }
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
