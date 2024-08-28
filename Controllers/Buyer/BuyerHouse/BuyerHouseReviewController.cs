using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Models.Houses;
using virtual_ex.Models;
using virtual_ex.RequestForms.BuyerRequestForms;
using Microsoft.AspNetCore.Identity;
using virtual_ex.Data;
using virtual_ex.MiddleWare;

namespace virtual_ex.Controllers.Buyer.BuyerHouse
{
    [Route("api/buyer-house/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class BuyerHouseReviewController(
            UserManager<UserModel> _userManager,
            ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext dBContext = _applicationDBContext;




        [HttpPatch("update-house-review")]
        public async Task<IActionResult> UpdateHouseAmenity([FromBody] BuyerReviewUpdateForm buyerReviewUpdateForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;

                // +++ Check if the product with the supplied ID exist
                var houseReviewModel = await dBContext.HouseReviewModels.FirstOrDefaultAsync(model => model.ReviewId.ToString() == buyerReviewUpdateForm.ReviewId);

                if (houseReviewModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                    new { message = "Sorry, your review for this product does not exist or no longer exist" }
                    );
                }


                var houseModel = await dBContext.HouseModels.FirstOrDefaultAsync(model => model.HouseId == houseReviewModel.HouseIdRelationship);

                if (houseModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "Sorry, this product you want to review could not be found or no longer exist" }
                        );
                }

                double initialRatings = (houseModel.ObtainableRatings * houseModel.Rating) / 5;
                double withRemovedInitalRatingSum = initialRatings - houseReviewModel.UserRating;
                double totalRating = ((withRemovedInitalRatingSum + buyerReviewUpdateForm.Rating) / (houseModel.ObtainableRatings)) * 5;

                houseModel.Rating = totalRating;
                houseReviewModel.UserRating = buyerReviewUpdateForm.Rating;
                houseReviewModel.Review = buyerReviewUpdateForm.Review;
                houseReviewModel.ModifiedDate = DateTime.UtcNow;

                await dBContext.SaveChangesAsync();

                return StatusCode
                    (
                        StatusCodes.Status200OK,
                        new { message = "Updated Successfully" }
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





        [HttpPost("register-house-review")]
        public async Task<IActionResult> RegisterHouseReview([FromBody] BuyerReviewRegisterForm buyerReviewRegisterForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;


                // +++ Check if the product with the supplied ID exist
                var houseModel = await dBContext.HouseModels.FirstOrDefaultAsync(model => model.HouseId.ToString() == buyerReviewRegisterForm.ProductId);

                if (houseModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "Sorry, this product could not be found or no longer exist" }
                        );
                }

                var isReviewed = await dBContext.HouseReviewModels
                    .FirstOrDefaultAsync(
                        model => model.HouseIdRelationship.ToString() == buyerReviewRegisterForm.ProductId && model.UserId.ToString() == user!.Id
                        );

                if (isReviewed != null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "Sorry, this product was already reviewed by this user", data = isReviewed }
                        );
                }


                double initalRatingSum = (houseModel.ObtainableRatings * houseModel.Rating) / 5;
                double obtainableRatings = houseModel.ObtainableRatings + 5;
                double totalRating = ((initalRatingSum + buyerReviewRegisterForm.Rating) / (obtainableRatings)) * 5;

                houseModel.Rating = totalRating;
                houseModel.ObtainableRatings = obtainableRatings;


                HouseReviewModel houseReviewModel = new()
                {
                    UserId = user!.Id,
                    HouseIdRelationship = Guid.Parse(buyerReviewRegisterForm.ProductId),
                    UserRating = buyerReviewRegisterForm.Rating,
                    Review = buyerReviewRegisterForm.Review,
                    HouseRelationship = houseModel
                };

                houseModel.HouseReviewRelationship.Add(houseReviewModel);

                await dBContext.AddAsync(houseReviewModel);
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
