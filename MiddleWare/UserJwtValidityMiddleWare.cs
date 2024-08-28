using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using virtual_ex.ControllerServices;
using virtual_ex.Models;

namespace virtual_ex.MiddleWare
{
    public class UserJwtValidityMiddleWare(
            UserManager<UserModel> _userManager
        ) : IAsyncActionFilter
    {

        private readonly UserManager<UserModel> userManager = _userManager;

        public async Task OnActionExecutionAsync (ActionExecutingContext httpContext, ActionExecutionDelegate next)
        {
            var context = httpContext.HttpContext;

            /*            using var scope = context.RequestServices.CreateScope();
                        var jwtTokenService = scope.ServiceProvider.GetService<IJwtTokenService>();

                        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(' ').Last();



                        if (string.IsNullOrEmpty(token))
                        { 
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            await context.Response.WriteAsync("This user credential could not be found");
                            context.Response.ContentType = "application/json";

                            // short-circuiting the pipeline
                            return;
                        }

                        var principal = await jwtTokenService.GetJWTPrincipal(token);

                        var principalUserID = (principal?.Claims.FirstOrDefault(c => c.Type == "UserId"))?.Value;


                        if (string.IsNullOrEmpty(principalUserID))
                        {
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            await context.Response.WriteAsync("This user credential could not be found");
                            context.Response.ContentType = "application/json";

                            // short-circuiting the pipeline
                            return;
                        }*/

            var principalUserID = "b149fd9f-398a-45f1-85bd-f07e64397ae5";


            var user = await userManager.FindByIdAsync(principalUserID);

            if (user == null || user.LockoutEnabled == true)
            {

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("This user could not be found or has been deactivated");
                context.Response.ContentType = "application/json";
                return;
            }


            context.Items["User"] = user;
            context.Items["UserID"] = principalUserID;

            //context.Items["JwtToken"] = token;



            await next();
        }

    }
}
