using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using virtual_ex.Models.Houses;
using virtual_ex.Models.Lands;
using virtual_ex.Models.Materials;
using Newtonsoft.Json;

namespace virtual_ex.Models
{


    public class UserModel : IdentityUser
    {
        public string? UserSelectedLocation { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiry { get; set; }



        //+++++++ RELATIONSHIPS +++++++
        public UserSellerModel? UserSellerRelationship { get; set; }
        public UserAgentModel? UserAgentRelationship { get; set; }
        public UserBuyerModel? UserBuyerRelationship { get; set; }


    }






    public class UserSellerAgentBaseModel
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        public string? MeansOfIdentity { get; set; }
        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
    }



    

    public class UserSellerModel: UserSellerAgentBaseModel
    {
        [Key]
        public Guid UserSellerId { get; set; }
        public bool? IsAnOrganization { get; set; }


        //+++++++ RELATIONSHIPS +++++++
        //ONE TO MANY
        public string? UserIdRelationship { get; set; }
        public UserModel UserRelationship { get; set; } = new UserModel();

        //MANY TO MANY
        // ------------------ PRODUCTS RELATIONSHIP ----------------
        public ICollection<HouseModel> HouseModelsRelationship { get; set; } = new List<HouseModel>();
        public ICollection<LandModel> LandModelsRelationship { get; set; } = new List<LandModel>();
        public ICollection<MaterialModel> MaterialModelsRelationship { get; set; } = new List<MaterialModel>();

        public ICollection<HouseReviewModel> HouseReviewRelationship { get; set; } = new List<HouseReviewModel>();
        public ICollection<LandReviewModel> LandReviewRelationship { get; set; } = new List<LandReviewModel>();
        public ICollection<MaterialReviewModel> MaterialReviewRelationship { get; set; } = new List<MaterialReviewModel>();

    }




    public class UserAgentModel: UserSellerAgentBaseModel
    {
        [Key]
        public Guid UserAgentId { get; set; }
        public bool IsAgentEngaged { get; set; } = false;
        public DateTime? EngagementExpiration { get; set; }


        //+++++++ RELATIONSHIPS +++++++
        //ONE TO MANY
        public string? UserIdRelationship { get; set; }
        public UserModel UserRelationship { get; set; } = new UserModel();


        // MNAY TO MANY
        public ICollection<HouseModel> HouseModelRelationship { get; set; } = new List<HouseModel>();
        public ICollection<LandModel> LandModelRelationship { get; set; } = new List<LandModel>();
        public ICollection<MaterialModel> MaterialModelRelationship { get; set; } = new List<MaterialModel>();

    }






    public class UserBuyerModel
    {

        [Key]
        public Guid UserBuyerId { get; set; }


        //+++++++ RELATIONSHIPS +++++++
        //ONE TO MANY
        public string? UserIdRelationship { get; set; }
        public UserModel UserRelationship { get; set; } = new UserModel();

        //MANY TO MANY
        public ICollection<HouseTransactionModel> HouseTransactionBuyerRelationship { get; set; } = new List<HouseTransactionModel>();
        public ICollection<HouseFavoritesModel> HouseFavoritesUserRelationship { get; set; } = new List<HouseFavoritesModel>();

        public ICollection<LandTransactionModel> LandTransactionBuyerRelationship { get; set; } = new List<LandTransactionModel>();
        public ICollection<LandFavoritesModel> LandFavoritesUserRelationship { get; set; } = new List<LandFavoritesModel>();

        public ICollection<MaterialTransactionModel> MaterialTransactionBuyerRelationship { get; set; } = new List<MaterialTransactionModel>();
        public ICollection<MaterialFavoritesModel> MaterialFavoritesUserRelationship { get; set; } = new List<MaterialFavoritesModel>();

    }



}
