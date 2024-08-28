using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace virtual_ex.Models.Materials
{
    public class MaterialModel
    {

        [Key]
        public Guid MaterialId { get; set; } = Guid.NewGuid();


        public bool IsScheduled { get; set; } = false;

        public bool AllowMultipleSchedule { get; set; } = false;

        [Required]
        public int NoOfMaterial { get; set; }

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
        public ICollection<MaterialAmenityModel> MaterialAmenitiesRelationship { get; set; } = new List<MaterialAmenityModel>();
        public ICollection<MaterialPictureModel> MaterialPicturesRelationship { get; set; } = new List<MaterialPictureModel>();
        public ICollection<MaterialPlacesNearbyModel> MaterialPlacesNearbyRelationship { get; set; } = new List<MaterialPlacesNearbyModel>();
        public ICollection<MaterialReviewModel> MaterialReviewRelationship { get; set; } = new List<MaterialReviewModel>();
        public ICollection<MaterialTransactionModel> MaterialTransactionRelationship { get; set; } = new List<MaterialTransactionModel>();
        public ICollection<MaterialFavoritesModel> MaterialFavoritesRelationship { get; set; } = new List<MaterialFavoritesModel>();

    }





    public class MaterialAmenityModel
    {
        [Key]
        public Guid MaterialAmenitiesId { get; set; } = Guid.NewGuid();

        public required string Amenity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS +++++++++++++
        public ICollection<MaterialModel> MaterialRelationship { get; set; } = new List<MaterialModel>();
    }


    public class MaterialPictureModel
    {
        [Key]
        public Guid PictureId { get; set; } = Guid.NewGuid();

        public required string Picture { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //++++++++++++++ RELATIONSHIPS ++++++++++
        public Guid? MaterialIdRelationship { get; set; }
        public MaterialModel? MaterialRelationship { get; set; }
    }


    public class MaterialPlacesNearbyModel
    {
        [Key]
        public Guid PlacesNearbyId { get; set; } = Guid.NewGuid();

        public required string Places { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }


        //+++++++++ RELATIONSHIPS ++++++++++++++++
        public ICollection<MaterialModel> MaterialRelationship { get; set; } = new List<MaterialModel>();
    }



    public class MaterialReviewModel
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

        public Guid? MaterialIdRelationship { get; set; }
        public MaterialModel? MaterialRelationship { get; set; }
    }

}
