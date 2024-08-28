
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using virtual_ex.ControllerServices;
using virtual_ex.Models;
using virtual_ex.RequestForms.SellerRequestForms;

namespace virtual_ex.Controllers.Admin.AdminAccount
{

    [Route("api/register-admin/")]
    [ApiController]
    public class RegisterAdminController
         (
        UserManager<UserModel> _userManager
        ) : ControllerBase
    {


        private readonly UserManager<UserModel> userManager = _userManager;


        [HttpGet("register"), Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Register([FromBody]  SellerSignUpForm userSignUp)
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


                await userManager.AddToRoleAsync(user, "Seller");


                return StatusCode(
                    StatusCodes.Status201Created,
                    new { message = "User was registered successfully", result }
                    );




            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong, please try again later" }
                    );
            }
        }


    }
}
