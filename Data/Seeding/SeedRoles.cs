using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace virtual_ex.Data.Seeding
{
    public class SeedRoles
    {

        
        public readonly IdentityRole superAdminRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "SuperAdmin",
            ConcurrencyStamp = "1",
            NormalizedName = "SuperAdmin"
        };




        public void SeedRolesFunction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
                (
                    superAdminRole,
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" },
                    new IdentityRole() { Name = "Seller", ConcurrencyStamp = "3", NormalizedName = "Seller" },
                    new IdentityRole() { Name = "Agent", ConcurrencyStamp = "4", NormalizedName = "Agent" },
                    new IdentityRole() { Name = "Buyer", ConcurrencyStamp = "5", NormalizedName = "Buyer" }
                );

        }


    }

}
