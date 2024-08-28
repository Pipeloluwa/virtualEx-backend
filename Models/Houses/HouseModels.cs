using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace virtual_ex.Models.Houses
{
    public class HouseModel
    {

        [Key]
        public Guid HouseId { get; set; } = Guid.NewGuid();

        public bool IsScheduled { get; set; } = false;

        public bool AllowMultipleSchedule { get; set; } = false;

        [Required]
        public required int NoOfHouse { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Price { get; set; }

        public required string CrossedPrice { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required string Location { get; set; }

        [Required]
        public required string CoverPicture { get; set; }


        [Required]
        public required string Video { get; set; }

        public double Rating { get; set; } = 0;

        public double ObtainableRatings { get; set; } = 0;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++++ RELATIONSHIPS ++++++++++++++
        //----------- ONE TO MANY --------------
        public required Guid UserSellerIdRelationship {  get; set; }
        public UserSellerModel UserSellerRelationship { get; set; } = new UserSellerModel();

        public required Guid AgentIdRelationship { get; set; }
        public UserAgentModel AgentRelationship { get; set; } = new UserAgentModel();


        //----------- MANY TO MANY ---------------
        public ICollection<HousePictureModel> HousePicturesRelationship { get; set; } = new List<HousePictureModel>();
        public ICollection<HouseAmenityModel> HouseAmenitiesRelationship { get; set; } = new List<HouseAmenityModel>();
        public ICollection<HousePlacesNearbyModel> HousePlacesNearbyRelationship { get; set; } = new List<HousePlacesNearbyModel>();
        public ICollection<HouseReviewModel> HouseReviewRelationship { get; set; } = new List<HouseReviewModel>();
        public ICollection<HouseTransactionModel> HouseTransactionRelationship { get; set; } = new List<HouseTransactionModel>();
        public ICollection<HouseFavoritesModel> HouseFavoritesRelationship { get; set; } = new List<HouseFavoritesModel>();

    }





    public class HouseAmenityModel
    {
        [Key]
        public Guid HouseAmenitiesId { get; set; } = Guid.NewGuid();

        public required string Amenity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS +++++++++++++
        public ICollection<HouseModel> HouseRelationship { get; set; } = new List<HouseModel>();
    }


    public class HousePictureModel
    {
        [Key]
        public Guid PictureId { get; set; } = Guid.NewGuid();

        public required string Picture { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //++++++++++++++ RELATIONSHIPS ++++++++++
        public Guid? HouseIdRelationship { get; set; }
        public HouseModel? HouseRelationship { get; set; }
    }


    public class HousePlacesNearbyModel
    {
        [Key]
        public Guid PlacesNearbyId { get; set; } = Guid.NewGuid();

        public required string Place { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS ++++++++++++++++
        public ICollection<HouseModel> HouseRelationship { get; set; } = new List<HouseModel>();
    }



    public class HouseReviewModel
    {
        [Key]
        public Guid ReviewId { get; set; } = Guid.NewGuid();

        public double UserRating {  get; set; }

        public string? Review { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }



        //++++++++++++ RELATIONSHIPS ++++++++++++++++
        public required string UserId { get; set; }
        public UserModel UserModelRelationship { get; set; } = new UserModel();

        public Guid? HouseIdRelationship { get; set; }
        public HouseModel? HouseRelationship { get; set; }
    }


}
