using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using virtual_ex.Data;
using virtual_ex.Models;
using virtual_ex.Models.Houses;
using virtual_ex.RequestForms.SellerRequestForms;

namespace virtual_ex.Controllers.Seller.SellerHouse
{
    [Route("api/seller-house/")]
    [ApiController]
    public class SellerHousePlaceNearbyController(UserManager<UserModel> _userManager,
            ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext dBContext = _applicationDBContext;




        [HttpPost("register-house-places-nearby")]
        public async Task<IActionResult> RegisterHousePlaceNearby([FromBody] SellerPlacesNearbyForm sellerPlacesNearbyForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }


                foreach (var place in sellerPlacesNearbyForm.Place)
                {
                    HousePlacesNearbyModel housePlacesNearbyModel = new()
                    {
                        Place = place.ToUpper(),
                    };

                    await dBContext.AddAsync(housePlacesNearbyModel);
                }

                await dBContext.SaveChangesAsync();

                return StatusCode
                    (
                        StatusCodes.Status201Created,
                        new { message = "Created Successfully" }
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
