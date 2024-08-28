using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Data;
using virtual_ex.MiddleWare;
using virtual_ex.Models;
using virtual_ex.Models.Houses;
using virtual_ex.RequestForms.SellerRequestForms;

namespace virtual_ex.Controllers.Seller.SellerHouse
{
    //[Authorize(Roles = "Seller")]
    [Route("api/seller-house/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class SellerHouseController
        (
            UserManager<UserModel> _userManager,
            ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext dBContext = _applicationDBContext;



        //+++++++++++++++++++  GET REQUESTS +++++++++++++++++++++++++++++
        [HttpGet("get-house-by-amenity")]
        public async Task<IActionResult> GetHouseByAmenity([FromQuery] string Amenity)
        {

            try
            {
                if (string.IsNullOrEmpty(Amenity))
                {
                    return BadRequest(new { message = "Please check your request detail, Amenity query is needed" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;

                var house = await dBContext.HouseModels
                    .Include(houseModel => houseModel.HouseAmenitiesRelationship)
                    .Include(houseModel => houseModel.HousePlacesNearbyRelationship)
                    .Include(houseModel => houseModel.HousePicturesRelationship)
                    .Where
                        (
                            houseModel =>
                                houseModel.UserSellerIdRelationship.ToString() == user!.Id
                                && houseModel.HouseAmenitiesRelationship.FirstOrDefault(houseAmenity => houseAmenity.Amenity == Amenity.ToUpper()) != null
                            ).ToListAsync();

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Your request was successful", data = house }
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



        [HttpGet("get-house-all")]
        public async Task<IActionResult> GetHouseAll()
        {

            try
            {

                UserModel user = HttpContext.Items["User"] as UserModel;

                var houses = await dBContext.HouseModels
                    .Include(model => model.HouseAmenitiesRelationship)
                    .Include(model => model.HousePlacesNearbyRelationship)
                    .Include(model => model.HousePicturesRelationship)
                    .Where(
                        model => model.UserSellerIdRelationship.ToString() == user!.Id).ToListAsync();

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









        //++++++++++++++++++++++ POST REQUESTS +++++++++++++++++++
        [HttpPost("register-house")]
        public async Task<IActionResult> RegisterHouse(SellerHouseCreateForm sellerHouseCreateForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;


                if (sellerHouseCreateForm.HousePicturesRelationship.Count > 10)
                {
                    return StatusCode
                        (
                            StatusCodes.Status400BadRequest,
                            new { message = "Only maximum of 10 picture slides allowed!" }
                        );
                }




                var houseAmenities = await dBContext.HouseAmenityModels
                    .Where(
                        model => sellerHouseCreateForm.HouseAmenitiesIds.Contains(model.HouseAmenitiesId.ToString())
                        ).ToListAsync();


                if (houseAmenities.Count != sellerHouseCreateForm.HouseAmenitiesIds.Count)
                {
                    return StatusCode(
                       StatusCodes.Status404NotFound,
                       new { message = "Not or none of all the House Amenity IDs you provided exist, please check and try again" }
                       );
                }


                var housePlacesNearbys = await dBContext.HousePlacesNearbyModels
                    .Where(
                        model => sellerHouseCreateForm.HousePlacesNearbyIds.Contains(model.PlacesNearbyId.ToString())
                        ).ToListAsync();


                if (housePlacesNearbys.Count != sellerHouseCreateForm.HousePlacesNearbyIds.Count)
                {
                    return StatusCode(
                       StatusCodes.Status404NotFound,
                        new { message = "Not or none of all the House PlacesNeraby IDs you provided exist, please check and try again" }
                       );
                }





                ICollection<HousePictureModel> housePictureModels = [];


                foreach (var picture in sellerHouseCreateForm.HousePicturesRelationship)
                {
                    HousePictureModel housePictureModel = new()
                    {
                        Picture = picture.FileName
                    };

                    housePictureModels.Add(housePictureModel);

                    await dBContext.AddAsync(housePictureModel);
                }



                UserAgentModel? userAgent = await dBContext.UserAgentModels
                    .FindAsync(Guid.Parse(sellerHouseCreateForm.AgentIdRelationship));

                if (userAgent == null)
                {
                    return StatusCode(
                       StatusCodes.Status404NotFound,
                        new { message = "The user agent assigned is not found or no longer exist" }
                       );
                }





                HouseModel houseModel = new()
                {
                    NoOfHouse = sellerHouseCreateForm.NoOfHouse,
                    Price = sellerHouseCreateForm.Price,
                    Title = sellerHouseCreateForm.Title.ToUpper(),
                    CrossedPrice = sellerHouseCreateForm.CrossedPrice,
                    Category = sellerHouseCreateForm.Category,
                    Description = sellerHouseCreateForm.Description,
                    Location = sellerHouseCreateForm.Location,
                    CoverPicture = sellerHouseCreateForm.CoverPicture.FileName,
                    Video = sellerHouseCreateForm.Video.FileName,
                    HousePicturesRelationship = housePictureModels,
                    HouseAmenitiesRelationship = houseAmenities,
                    HousePlacesNearbyRelationship = housePlacesNearbys,

                    UserSellerIdRelationship = Guid.Parse(user!.Id),
                    UserSellerRelationship = user.UserSellerRelationship,

                    AgentIdRelationship= Guid.Parse(sellerHouseCreateForm.AgentIdRelationship),
                    AgentRelationship= userAgent
                };


                await dBContext.AddAsync(houseModel);
                await dBContext.SaveChangesAsync();


                return StatusCode
                    (
                        StatusCodes.Status201Created,
                        new { message = "Created Successfully" }
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
