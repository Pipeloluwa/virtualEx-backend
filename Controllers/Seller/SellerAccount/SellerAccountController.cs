using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using virtual_ex.ControllerServices;
using virtual_ex.MiddleWare;
using virtual_ex.Models;
using virtual_ex.RequestForms.SellerRequestForms;
using virtual_ex.ResponseForms.SellerResponseForms;

namespace virtual_ex.Controllers.Seller.SellerAccount
{
    [Authorize(Roles = "Seller")]
    [Route("api/seller-account/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class SellerAccountController
        (
            UserManager<UserModel> _userManager
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;



        [HttpGet("get-profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                UserModel user = HttpContext.Items["User"] as UserModel;


                SellerProfileResponse sellerProfileResponse = new(user.UserSellerRelationship);

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "User gotten successfully", user = sellerProfileResponse }
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



        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] SellerUpdateForm sellerUpdateForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;

                user.UserSellerRelationship.FirstName = sellerUpdateForm.FirstName;
                user.UserSellerRelationship.LastName = sellerUpdateForm.LastName;
                user.UserSellerRelationship.Address = sellerUpdateForm.Address;
                user.UserSellerRelationship.MeansOfIdentity = sellerUpdateForm.MeansOfIdentity == null ? user.UserSellerRelationship.MeansOfIdentity : sellerUpdateForm.MeansOfIdentity.FileName;
                user.UserSelectedLocation = sellerUpdateForm.UserSelectedLocation;
                user.UserSellerRelationship.IsAnOrganization = sellerUpdateForm.IsAnOrganization;
                user.PhoneNumber = sellerUpdateForm.PhoneNumber;
                user.ModifiedDate= DateTime.UtcNow;


                IdentityResult result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return StatusCode
                            (
                                StatusCodes.Status500InternalServerError,
                                new { message = "Sorry, something went wrong, could not update user" }
                            );
                }


                SellerProfileResponse sellerProfileResponse = new (user.UserSellerRelationship);

                return StatusCode
                            (
                                StatusCodes.Status200OK,
                                new { message = "User updated successfully", user = sellerProfileResponse }
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
