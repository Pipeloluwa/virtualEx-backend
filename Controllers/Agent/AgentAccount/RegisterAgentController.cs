using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using virtual_ex.ControllerServices;
using virtual_ex.Data;
using virtual_ex.Models;
using virtual_ex.RequestForms.SellerRequestForms;

namespace virtual_ex.Controllers.Agent.AgentAccount
{
    [Route("api/register-agent/")]
    [ApiController]
    public class RegisterAgentController(
        UserManager<UserModel> _userManager,
        ApplicationDBContext _applicationDBContext
        ) : ControllerBase
    {


        private readonly UserManager<UserModel> userManager = _userManager;

        [HttpPost("register")]
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
                    PhoneNumber = userSignUp.PhoneNumber,
                    EmailConfirmed = true

                };


                UserAgentModel userAgentModel = new()
                {
                    UserAgentId = Guid.Parse(user.Id),
                    FirstName = userSignUp.FirstName,
                    LastName = userSignUp.LastName,
                    Address = userSignUp.Address,
                    MeansOfIdentity = userSignUp.MeansOfIdentity,
                    ProfilePicture = userSignUp.ProfilePicture,
                    UserIdRelationship = user.Id,
                    UserRelationship = user
                };

                await _applicationDBContext.AddAsync(userAgentModel);



                IdentityResult result = await userManager.CreateAsync(user, userSignUp.Password);

                if (!result.Succeeded)
                {
                    return StatusCode
                        (
                            StatusCodes.Status500InternalServerError,
                            new { message = "Sorry, something went wrong, could not create user" }
                        );
                }


                await userManager.AddToRoleAsync(user, "Agent");

                await _applicationDBContext.SaveChangesAsync();

                return StatusCode(
                    StatusCodes.Status201Created,
                    new { message = "User was registered successfully", result }
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
