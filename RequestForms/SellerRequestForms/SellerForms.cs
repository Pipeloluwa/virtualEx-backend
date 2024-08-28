using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using virtual_ex.Models.Houses;
using virtual_ex.Models;

namespace virtual_ex.RequestForms.SellerRequestForms
{
    public class SellerHouseCreateForm
    {
        public required string AgentIdRelationship { get; set; }

        public required int NoOfHouse { get; set; }

        [MaxLength(30)]
        public required string Title { get; set; }

        [MaxLength(200)]
        public required string Description { get; set; }

        public required string Price { get; set; }

        public required string CrossedPrice { get; set; }

        public required string Category { get; set; }

        public required string Location { get; set; }

        public required ICollection<string> HouseAmenitiesIds { get; set; }

        public required ICollection<string> HousePlacesNearbyIds { get; set; }

        public required IFormFile CoverPicture { get; set; }

        public required ICollection<IFormFile> HousePicturesRelationship { get; set; }

        public required IFormFile Video { get; set; }

    }





    public class SellerAmenitiesForm
    {
        public required ICollection<string> Amenity {  get; set; }
    }



    public class SellerPlacesNearbyForm
    {
        public required ICollection<string> Place { get; set; }
    }



}
