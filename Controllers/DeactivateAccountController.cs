using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using virtual_ex.MiddleWare;
using virtual_ex.Models;

namespace virtual_ex.Controllers
{

    [Authorize(Roles = "Seller,Buyer")]
    [Route("api/deactivate-account")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class DeactivateAccountController
        (
            UserManager<UserModel> _userManager
        ) : ControllerBase
    {

        private readonly UserManager<UserModel> userManager = _userManager;


        [HttpGet("")]
        public async Task<IActionResult> DeleteProfile()
        {
            try
            {
                UserModel user = HttpContext.Items["User"] as UserModel;

                user!.LockoutEnabled = true;
                user.RefreshToken = null;
                HttpContext.Items["JwtToken"] = "";
                HttpContext.Items["UserID"] = "";

                IdentityResult result = await userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return StatusCode
                            (
                                StatusCodes.Status500InternalServerError,
                                new { message = "Sorry, something went wrong, could not deactivae the user" }
                            );
                }



                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "User data deactivated successfully" }
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
