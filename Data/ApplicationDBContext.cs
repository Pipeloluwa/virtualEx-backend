using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using virtual_ex.Data.Seeding;
using virtual_ex.Models;
using virtual_ex.Models.Houses;

namespace virtual_ex.Data
{
    public class ApplicationDBContext: IdentityDbContext<UserModel>
    {
        private readonly UserModelBuilder userModelBuilder= new ();
        private readonly HouseModelBuilder houseModelBuilder= new();
        private readonly LandModelBuilder landModelBuilder= new();
        private readonly MaterialModelBuilder materialModelBuilder = new();

        private readonly SeedRoles seedRoles = new ();
        private readonly SeedSuperAdminUser seedSuperAdminUser = new ();
        private readonly SeedSuperAdminRole seedSuperAdminRole = new ();
        private readonly SeedScheduleSettings seedScheduleSettings = new ();




        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //++++++++++++++++++++ SEEDING ++++++++++++++++++++++++++++
            seedRoles.SeedRolesFunction(modelBuilder);
            seedSuperAdminUser.SeedSuperAdminUserFunction(modelBuilder);
            seedSuperAdminRole.SeedSuperAdminRoleFunction(modelBuilder, seedRoles.superAdminRole.Id, seedSuperAdminUser.superAdminUser.Id);
            seedScheduleSettings.SeedScheduleSettingsFunction(modelBuilder);


            //++++++++++++++ CREATING RELATIONSHIP TABLES ++++++++++++
            userModelBuilder.UserBuilder(modelBuilder);
            houseModelBuilder.HouseBuilder(modelBuilder);
            landModelBuilder.LandBuilder(modelBuilder);
            materialModelBuilder.MaterialBuilder(modelBuilder);

        }




        // +++++++++++++++++ ADMIN +++++++++++++++++
        public DbSet<ScheduleSettingsModel> ScheduleSettingsModels { get; set; }


        // ++++++++++++++ User ++++++++++++++++++
        public DbSet<UserModel> UserModels {  get; set; }
        public DbSet<UserSellerModel> UserSellerModels { get; set; }
        public DbSet<UserAgentModel> UserAgentModels { get; set; }
        public DbSet<UserBuyerModel> UserBuyerModels {  get; set; }


        //++++++++++++ HOUSE +++++++++++++++++
        public DbSet<HouseModel> HouseModels { get; set; }
        public DbSet<HouseAmenityModel> HouseAmenityModels { get; set; }
        public DbSet<HousePictureModel> HousePicturesModels { get; set; }
        public DbSet<HousePlacesNearbyModel> HousePlacesNearbyModels { get; set; }
        public DbSet<HouseReviewModel> HouseReviewModels { get; set; }
        public DbSet<HouseFavoritesModel> HouseFavoritesModels { get; set; }
        public DbSet<HouseTransactionModel> HouseTransactionModels { get; set; }


        //++++++++++++ LAND +++++++++++++++++
        public DbSet<HouseModel> LandModels { get; set; }
        public DbSet<HouseAmenityModel> LandeAmenities { get; set; }
        public DbSet<HousePictureModel> LandPicturesModels { get; set; }
        public DbSet<HousePlacesNearbyModel> LandPlacesNearbyModels { get; set; }
        public DbSet<HouseReviewModel> LandReviewModels { get; set; }
        public DbSet<HouseFavoritesModel> LandFavoritesModels { get; set; }
        public DbSet<HouseTransactionModel> LandTransactionModels { get; set; }


        //++++++++++++ MATERIAL +++++++++++++++++
        public DbSet<HouseModel> MaterialModels { get; set; }
        public DbSet<HouseAmenityModel> MaterialAmenities { get; set; }
        public DbSet<HousePictureModel> MaterialPicturesModels { get; set; }
        public DbSet<HousePlacesNearbyModel> MaterialPlacesNearbyModels { get; set; }
        public DbSet<HouseReviewModel> MaterialReviewModels { get; set; }
        public DbSet<HouseFavoritesModel> MaterialFavoritesModels { get; set; }
        public DbSet<HouseTransactionModel> MaterialTransactionModels { get; set; }


    }
}
