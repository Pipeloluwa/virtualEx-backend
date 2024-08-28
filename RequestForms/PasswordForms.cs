using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace virtual_ex.RequestForms
{
    public class RequestPasswordResetForm
    {
        public required string Email { get; set; }
    }



    public class ChangePasswordForm
    {
        public required string OldPassword { get; set; }

        [MinLength(6)]
        public required string NewPassword { get; set; }
    }


    public class ResetPasswordForm
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string New_Password { get; set; }
    }
}
