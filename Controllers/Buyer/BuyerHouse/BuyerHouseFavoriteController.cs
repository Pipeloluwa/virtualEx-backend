using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Data;
using virtual_ex.MiddleWare;
using virtual_ex.Models;
using virtual_ex.Models.Houses;
using virtual_ex.RequestForms.BuyerRequestForms;
using virtual_ex.ResponseForms.BuyerResponseForms;

namespace virtual_ex.Controllers.Buyer.BuyerHouse
{
    [Route("api/buyer-house/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class BuyerHouseFavoriteController(
            UserManager<UserModel> _userManager,
            ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext dBContext = _applicationDBContext;



        [HttpGet("get-house-favorites")]
        public async Task<IActionResult> GetHouseFavorites()
        {
            try
            {
                UserModel user = HttpContext.Items["User"] as UserModel;

                var houses = await dBContext.HouseFavoritesModels
                    .Include(model => model.HouseRelationship)
                    .Where(model => model.UserIdRelationship == Guid.Parse(user!.Id))
                    .Select(model => new BuyerHouseFavoritesResponse(model))
                    .ToListAsync();


                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Your request was successful", data = houses }
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





        [HttpDelete("delete-house-favorite")]
        public async Task<IActionResult> UpdateHouseAmenity([FromBody] BuyerProductForm buyerProductForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;

                // +++ Check if the product with the supplied ID exist
                var houseModel = await dBContext.HouseModels.FirstOrDefaultAsync(model => model.HouseId.ToString() == buyerProductForm.ProductId);

                if (houseModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "Sorry, this product could not be found or no longer exist" }
                        );
                }

                var existingFavorite = await dBContext.HouseFavoritesModels
                    .FirstOrDefaultAsync(
                        model => model.HouseIdRelationship.ToString() == buyerProductForm.ProductId && model.UserIdRelationship.ToString() == user!.Id
                        );

                if (existingFavorite == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "Sorry, this product has been removed or is no longer in the favorites list of this user" }
                        );
                }


                dBContext.Remove(existingFavorite);
                await dBContext.SaveChangesAsync();

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Deleted Successfully" }
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






        [HttpPost("register-house-favorite")]
        public async Task<IActionResult> RegisterHouseFavorite([FromBody] BuyerProductForm buyerProductForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;


                // +++ Check if the product with the supplied ID exist
                var houseModel = await dBContext.HouseModels.FirstOrDefaultAsync(model => model.HouseId.ToString() == buyerProductForm.ProductId);

                if (houseModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "Sorry, this product could not be found or no longer exist" }
                        );
                }

                var existingFavorite = await dBContext.HouseFavoritesModels
                    .FirstOrDefaultAsync(
                        model => model.HouseIdRelationship.ToString() == buyerProductForm.ProductId && model.UserIdRelationship.ToString() == user!.Id
                        );

                if (existingFavorite != null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "Sorry, this product was already added to favorite by this user" }
                        );
                }




                HouseFavoritesModel houseFavoritesModel = new()
                {
                    HouseIdRelationship = houseModel.HouseId,
                    UserIdRelationship = Guid.Parse(user!.Id),
                    HouseRelationship = houseModel,
                    UserRelationship = user.UserBuyerRelationship,
                };

                user.UserBuyerRelationship.HouseFavoritesUserRelationship.Add(houseFavoritesModel);
                houseModel.HouseFavoritesRelationship.Add(houseFavoritesModel);

                await dBContext.AddAsync(houseFavoritesModel);
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
