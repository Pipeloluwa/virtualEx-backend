using Microsoft.EntityFrameworkCore;
using virtual_ex.Models;
using virtual_ex.Models.Houses;

namespace virtual_ex.Data
{
    public class HouseModelBuilder
    {

        public void HouseBuilder(ModelBuilder modelBuilder)
        {
            //++++++++++++ ONE TO MANY ++++++++++++++++++++
            modelBuilder.Entity<UserSellerModel>()
                .HasMany(m => m.HouseModelsRelationship)
                .WithOne(o => o.UserSellerRelationship)
                .HasForeignKey(k => k.UserSellerIdRelationship);

            modelBuilder.Entity<UserAgentModel>()
                .HasMany(m => m.HouseModelRelationship)
                .WithOne(o => o.AgentRelationship)
                .HasForeignKey(k => k.AgentIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.HouseTransactionBuyerRelationship)
                .WithOne(o => o.UserBuyerRelationship)
                .HasForeignKey(k => k.UserBuyerIdRelationship);


            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HouseTransactionRelationship)
                .WithOne(o => o.HouseRelationship)
                .HasForeignKey(k => k.HouseIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.HouseFavoritesUserRelationship)
                .WithOne(o => o.UserRelationship)
                .HasForeignKey(k => k.UserIdRelationship);

            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HouseFavoritesRelationship)
                .WithOne(o => o.HouseRelationship)
                .HasForeignKey(k => k.HouseIdRelationship);

            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HousePicturesRelationship)
                .WithOne(o => o.HouseRelationship)
                .HasForeignKey(k => k.HouseIdRelationship);

            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HouseReviewRelationship)
                .WithOne(o => o.HouseRelationship).
                HasForeignKey(k => k.HouseIdRelationship);




            //++++++++++++++ MANY TO MANY ++++++++
            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HouseAmenitiesRelationship)
                .WithMany(m => m.HouseRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "HouseJoinHouseAmenityModel",
                        j => j.HasOne<HouseAmenityModel>().WithMany().HasForeignKey("HouseAmenityId"),
                        j => j.HasOne<HouseModel>().WithMany().HasForeignKey("HouseModelId")
                    );

            modelBuilder.Entity<HouseModel>()
                .HasMany(m => m.HousePlacesNearbyRelationship)
                .WithMany(m => m.HouseRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "HouseJoinPlacesNearbyModel",
                        j => j.HasOne<HousePlacesNearbyModel>().WithMany().HasForeignKey("PlacesNearbyId"),
                        j => j.HasOne<HouseModel>().WithMany().HasForeignKey("HouseModelId")
                    );

        }

    }
}
