using System.ComponentModel.DataAnnotations;

namespace virtual_ex.RequestForms.SellerRequestForms
{
    public class SellerUpdateForm
    {

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(50)]
        public required string Address { get; set; }
        public required string UserSelectedLocation { get; set; }

        public IFormFile? MeansOfIdentity { get; set; }
        public required bool IsAnOrganization { get; set; }

        public required string PhoneNumber { get; set; }

    }
}
