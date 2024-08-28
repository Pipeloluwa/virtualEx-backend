using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace virtual_ex.Models.Lands
{
    public class LandModel
    {

        [Key]
        public Guid LandId { get; set; } = Guid.NewGuid();

        public bool IsScheduled { get; set; } = false;

        public bool AllowMultipleSchedule { get; set; } = false;

        [Required]
        public int NoOfLand { get; set; }

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

        public required string PlacesNearby { get; set; }

        public double? Rating { get; set; } = 0;

        public double ObtainableRatings { get; set; } = 0;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++++ RELATIONSHIPS ++++++++++++++
        //----------- ONE TO MANY --------------
        public required Guid UserSellerIdRelationship { get; set; }
        public UserSellerModel UserSellerRelationship { get; set; } = new UserSellerModel();

        public required Guid AgentIdRelationship { get; set; }
        public UserAgentModel AgentRelationship { get; set; } = new UserAgentModel();


        //----------- MANY TO MANY ---------------
        public ICollection<LandAmenityModel> LandAmenitiesRelationship { get; set; } = new List<LandAmenityModel>();
        public ICollection<LandPictureModel> LandPicturesRelationship { get; set; } = new List<LandPictureModel>();
        public ICollection<LandPlacesNearbyModel> LandPlacesNearbyRelationship { get; set; } = new List<LandPlacesNearbyModel>();
        public ICollection<LandReviewModel> LandReviewRelationship { get; set; } = new List<LandReviewModel>();
        public ICollection<LandTransactionModel> LandTransactionRelationship { get; set; } = new List<LandTransactionModel>();
        public ICollection<LandFavoritesModel> LandFavoritesRelationship { get; set; } = new List<LandFavoritesModel>();

    }





    public class LandAmenityModel
    {
        [Key]
        public Guid LandAmenitiesId { get; set; } = Guid.NewGuid();

        public required string Amenity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS +++++++++++++
        public ICollection<LandModel> LandRelationship { get; set; } = new List<LandModel>();
    }


    public class LandPictureModel
    {
        [Key]
        public Guid PictureId { get; set; } = Guid.NewGuid();

        public required string Picture { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //++++++++++++++ RELATIONSHIPS ++++++++++
        public Guid LandIdRelationship { get; set; }
        public LandModel? LandRelationship { get; set; }
    }


    public class LandPlacesNearbyModel
    {
        [Key]
        public Guid PlacesNearbyId { get; set; } = Guid.NewGuid();

        public required string Places { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS ++++++++++++++++
        public ICollection<LandModel> LandRelationship { get; set; } = new List<LandModel>();
    }



    public class LandReviewModel
    {
        [Key]
        public Guid ReviewId { get; set; } = Guid.NewGuid();

        public double UserRating { get; set; }

        public string? Review { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }



        //++++++++++++ RELATIONSHIPS ++++++++++++++++
        public required string UserId { get; set; }
        public UserModel UserModelRelationship { get; set; } = new UserModel();

        public Guid? LandIdRelationship { get; set; }
        public LandModel? LandRelationship { get; set; }
    }

}
