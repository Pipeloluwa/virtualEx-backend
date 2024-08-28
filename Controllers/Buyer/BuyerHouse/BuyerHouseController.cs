using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Data;
using virtual_ex.MiddleWare;
using virtual_ex.Models;
using virtual_ex.Models.Houses;
using virtual_ex.RequestForms.BuyerRequestForms;
using virtual_ex.RequestForms.SellerRequestForms;
using virtual_ex.ResponseForms.BuyerResponseForms;

namespace virtual_ex.Controllers.Buyer.BuyerHouse
{
    [Route("api/buyer-house/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class BuyerHouseController(
            UserManager<UserModel> _userManager,
            ApplicationDBContext _dBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext _applicationDBContext = _dBContext;







        [HttpGet("get-house-all")]
        public async Task<IActionResult> GetHouseAll()
        {
            try
            {
                UserModel user = HttpContext.Items["User"] as UserModel;

                var houses = await _applicationDBContext.HouseModels
                    .Include(model => model.HouseAmenitiesRelationship)
                    .Include(model => model.HousePlacesNearbyRelationship)
                    .Include(model => model.HousePicturesRelationship)
                    .Select(model => new BuyerHouseBaseResponse(model))
                    .ToListAsync();

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Your request was successful", data = houses }
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
