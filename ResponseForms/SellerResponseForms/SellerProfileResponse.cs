using virtual_ex.Models;

namespace virtual_ex.ResponseForms.SellerResponseForms
{
    public class SellerProfileResponse(UserSellerModel? user)
    {

        public string? Id { get; set; } = user.UserIdRelationship;
        public string? UserName { get; set; } = user.UserRelationship.UserName;
        public string? Email { get; set; } = user.UserRelationship.Email;
        public string? PhoneNumber { get; set; } = user.UserRelationship.PhoneNumber;
        public string? FirstName { get; set; } = user.FirstName;
        public string? LastName { get; set; } = user.LastName;
        public string? UserSelectedLocation { get; set; } = user.UserRelationship.UserSelectedLocation;
        public string? Address { get; set; } = user.Address;
        public bool? IsAnOrganiazation { get; set; } = user.IsAnOrganization;
        public string? CreatedDate { get; set; } = user.UserRelationship.CreatedDate.ToString();


    }



}
