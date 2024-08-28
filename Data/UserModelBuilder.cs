using Microsoft.EntityFrameworkCore;
using virtual_ex.Models;

namespace virtual_ex.Data
{
    public class UserModelBuilder
    {

        public void UserBuilder(ModelBuilder modelBuilder)
        {
            // +++++++ SELLER ++++++++
            modelBuilder.Entity<UserModel>()
               .HasOne(o => o.UserSellerRelationship)
               .WithOne(o => o.UserRelationship)
               .HasForeignKey<UserSellerModel>(k => k.UserIdRelationship);

            // ++++++++ AGENT +++++++++
            modelBuilder.Entity<UserModel>()
                .HasOne(m => m.UserAgentRelationship)
                .WithOne(o => o.UserRelationship)
                .HasForeignKey<UserAgentModel>(k => k.UserIdRelationship);

            // +++++++++ BUYER ++++++++++
            modelBuilder.Entity<UserModel>()
                .HasOne(m => m.UserBuyerRelationship)
                .WithOne(o => o.UserRelationship)
                .HasForeignKey<UserBuyerModel>(k => k.UserIdRelationship);
        }

    }
}
