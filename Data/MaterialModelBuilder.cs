using Microsoft.EntityFrameworkCore;
using virtual_ex.Models.Materials;
using virtual_ex.Models;

namespace virtual_ex.Data
{
    public class MaterialModelBuilder
    {

        public void MaterialBuilder(ModelBuilder modelBuilder)
        {
            //++++++++++++ ONE TO MANY ++++++++++++++++++++
            modelBuilder.Entity<UserSellerModel>()
                .HasMany(m => m.MaterialModelsRelationship)
                .WithOne(o => o.UserSellerRelationship)
                .HasForeignKey(k => k.UserSellerIdRelationship);

            modelBuilder.Entity<UserAgentModel>()
                .HasMany(m => m.MaterialModelRelationship)
                .WithOne(o => o.AgentRelationship)
                .HasForeignKey(k => k.AgentIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.MaterialTransactionBuyerRelationship)
                .WithOne(o => o.UserBuyerRelationship)
                .HasForeignKey(k => k.UserBuyerIdRelationship);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialTransactionRelationship)
                .WithOne(o => o.MaterialRelationship)
                .HasForeignKey(k => k.MaterialIdRelationship);

            modelBuilder.Entity<UserBuyerModel>()
                .HasMany(m => m.MaterialFavoritesUserRelationship)
                .WithOne(o => o.UserRelationship)
                .HasForeignKey(k => k.UserIdRelationship);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialFavoritesRelationship)
                .WithOne(o => o.MaterialRelationship)
                .HasForeignKey(k => k.MaterialIdRelationship);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialPicturesRelationship)
                .WithOne(o => o.MaterialRelationship)
                .HasForeignKey(k => k.MaterialIdRelationship);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialReviewRelationship)
                .WithOne(o => o.MaterialRelationship).
                HasForeignKey(k => k.MaterialIdRelationship);



            //++++++++++++++ MANY TO MANY ++++++++
            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialAmenitiesRelationship)
                .WithMany(m => m.MaterialRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "MaterialJoinMaterialAmenityModel",
                        j => j.HasOne<MaterialAmenityModel>().WithMany().HasForeignKey("MaterialAmenityId"),
                        j => j.HasOne<MaterialModel>().WithMany().HasForeignKey("MaterialModelId")
                    );

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialPlacesNearbyRelationship)
                .WithMany(m => m.MaterialRelationship)
                .UsingEntity<Dictionary<string, object>>
                    (
                        "MaterialJoinPlacesNearbyModel",
                        j => j.HasOne<MaterialPlacesNearbyModel>().WithMany().HasForeignKey("PlacesNearbyId"),
                        j => j.HasOne<MaterialModel>().WithMany().HasForeignKey("MaterialModelId")
                    );


        }

    }
}
