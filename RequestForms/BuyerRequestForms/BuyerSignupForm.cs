using System.ComponentModel.DataAnnotations;

namespace virtual_ex.RequestForms.BuyerRequestForms
{
    public class BuyerSignupForm
    {
        [MaxLength(50)]
        public required string UserName { get; set; }

        [MaxLength(50)]
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }
    }
}
