using System.ComponentModel.DataAnnotations;

namespace virtual_ex.RequestForms.SellerRequestForms
{
    public class SellerSignUpForm
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(50)]
        public required string Address { get; set; }

        public required string MeansOfIdentity { get; set; }
        public required bool Is_An_Organization { get; set; }

        [MaxLength(50)]
        public required string UserName { get; set; }

        [MaxLength(50)]
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string ProfilePicture {  get; set; }

        [MinLength(6)]
        public required string Password { get; set; }


    }
}
