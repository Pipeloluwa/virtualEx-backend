using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Models.Houses;
using virtual_ex.Models;
using virtual_ex.RequestForms.BuyerRequestForms;
using Microsoft.AspNetCore.Identity;
using virtual_ex.Data;
using virtual_ex.MiddleWare;
using Org.BouncyCastle.Crypto.Prng;

namespace virtual_ex.Controllers.Buyer.BuyerHouse
{
    [Route("api/buyer-house/")]
    [ApiController]
    [ServiceFilter(typeof(UserJwtValidityMiddleWare))]
    public class BuyerHouseTransactionController(
            UserManager<UserModel> _userManager,
            ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {
        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly ApplicationDBContext dBContext = _applicationDBContext;


        [HttpPost("register-house-transaction")]
        public async Task<IActionResult> RegisterHouseTransaction([FromBody] BuyerTransactionForm buyerTransactionForm)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Please check your request details" });
                }

                UserModel user = HttpContext.Items["User"] as UserModel;



                // +++ Check if the product with the supplied ID exist
                var houseModel = await dBContext.HouseModels.FirstOrDefaultAsync(model => model.HouseId.ToString() == buyerTransactionForm.ProductId);

                if (houseModel == null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status404NotFound,
                            new { message = "Sorry, this product could not be found or no longer exist" }
                        );
                }

                var existingTransaction = await dBContext.HouseTransactionModels
                    .FirstOrDefaultAsync(
                        model => model.HouseIdRelationship.ToString() == buyerTransactionForm.ProductId && model.UserBuyerIdRelationship.ToString() == user!.Id
                        );

                if (existingTransaction != null)
                {
                    return StatusCode
                        (
                            StatusCodes.Status409Conflict,
                            new { message = "Sorry, this product was already added to the transaction or alert list by this user" }
                        );
                }




                ScheduleSettingsModel scheduleSettingsModel = await dBContext.ScheduleSettingsModels.Order().FirstAsync();

                string schedulFee = buyerTransactionForm.IsNormalBuy ? scheduleSettingsModel!.NormalScheduledFee : scheduleSettingsModel!.CustomScheduledFee;


                HouseTransactionModel houseTransactionModel = new()
                {
                    HouseIdRelationship = houseModel.HouseId,
                    IsNormalBuy = buyerTransactionForm.IsNormalBuy,
                    Quantity= buyerTransactionForm.Quantity,
                    ScheduleFee= schedulFee,
                    UserBuyerIdRelationship = Guid.Parse(user!.Id),

                    UserBuyerRelationship= user.UserBuyerRelationship,
                    HouseRelationship = houseModel,

                    ScheduleInitiatedDate = DateTime.UtcNow,
                };


                await dBContext.AddAsync(houseTransactionModel);
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
