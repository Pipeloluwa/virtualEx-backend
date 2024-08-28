using Microsoft.EntityFrameworkCore;
using virtual_ex.Models;
using virtual_ex.Models.Lands;

namespace virtual_ex.Data
{
    public class LandModelBuilder
    {

        public void LandBuilder(ModelBuilder modelBuilder)
        {
            //++++++++++++ ONE TO MANY ++++++++++++++++++++
            modelBuilder.Entity<UserSellerModel>()
                .HasMany(m => m.LandModelsRelationship)
                .WithOne(o => o.UserSellerRelationship)
                .HasForeignKey(k => k.UserSellerIdRelationship);

            modelBuilder.Entity<UserAgentModel>()
                .HasMany(m => m.LandModelRelationship)
                .WithOne(o => o.AgentRelationship)
                .HasForeignKey(k => k.AgentIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.LandTransactionBuyerRelationship)
                .WithOne(o => o.UserBuyerRelationship)
                .HasForeignKey(k => k.UserBuyerIdRelationship);


            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandTransactionRelationship)
                .WithOne(o => o.LandRelationship)
                .HasForeignKey(k => k.LandIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.LandFavoritesUserRelationship)
                .WithOne(o => o.UserRelationship)
                .HasForeignKey(k => k.UserIdRelationship);

            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandFavoritesRelationship)
                .WithOne(o => o.LandRelationship)
                .HasForeignKey(k => k.LandIdRelationship);

            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandPicturesRelationship)
                .WithOne(o => o.LandRelationship)
                .HasForeignKey(k => k.LandIdRelationship);

            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandReviewRelationship)
                .WithOne(o => o.LandRelationship).
                HasForeignKey(k => k.LandIdRelationship);



            //++++++++++++++ ManyToManyJoinEntityTypeConvention TO MANY ++++++++
            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandAmenitiesRelationship)
                .WithMany(m => m.LandRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "LandJoinLandAmenityModel",
                        j => j.HasOne<LandAmenityModel>().WithMany().HasForeignKey("LandAmenityId"),
                        j => j.HasOne<LandModel>().WithMany().HasForeignKey("LandModelId")
                    );

            modelBuilder.Entity<LandModel>()
                .HasMany(m => m.LandPlacesNearbyRelationship)
                .WithMany(m => m.LandRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "LandJoinPlacesNearbyModel",
                        j => j.HasOne<LandPlacesNearbyModel>().WithMany().HasForeignKey("PlacesNearbyId"),
                        j => j.HasOne<LandModel>().WithMany().HasForeignKey("LandModelId")
                    );


        }

    }
}
