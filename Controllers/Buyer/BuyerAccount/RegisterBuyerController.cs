using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using virtual_ex.ControllerServices;
using virtual_ex.Models;
using virtual_ex.RequestForms.BuyerRequestForms;

namespace virtual_ex.Controllers.Buyer.BuyerAccount
{
    [Route("api/register-buyer/")]
    [ApiController]
    public class RegisterBuyerController
         (
        UserManager<UserModel> _userManager
        ) : ControllerBase
    {


        private readonly UserManager<UserModel> userManager = _userManager;


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] BuyerSignupForm userSignUp)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode
                        (
                        StatusCodes.Status400BadRequest,
                        new { message = "Please check your request details" }
                        );
                }


                var existingUser = await userManager.FindByEmailAsync(userSignUp.Email);

                if (existingUser != null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "User with this email already exists" }
                        );
                }


                if (existingUser != null && existingUser.UserName == userSignUp.UserName)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "User with this username already exists" }
                        );
                }


                UserModel user = new()
                {

                    UserName = userSignUp.UserName,
                    Email = userSignUp.Email,
                    PhoneNumber = userSignUp.PhoneNumber

                };




                IdentityResult result = await userManager.CreateAsync(user, userSignUp.Password);

                if (!result.Succeeded)
                {
                    return StatusCode
                        (
                            StatusCodes.Status500InternalServerError,
                            new { message = "Sorry, something went wrong, could not create user" }
                        );
                }


                await userManager.AddToRoleAsync(user, "Buyer");


                Console.WriteLine("++++++++++++This is User Details Below");
                Console.WriteLine(result);

                return StatusCode(
                    StatusCodes.Status201Created,
                    new { message = "User registered successfully", result }
                    );




            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong, please try again later" }
                    );
            }
        }


    }
}
