using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace virtual_ex.Data.Seeding
{
    public class SeedSuperAdminRole
    {


        public void SeedSuperAdminRoleFunction(ModelBuilder modelBuilder, string superAdminRoleId, string superAdminUserId)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string> { RoleId = superAdminRoleId, UserId = superAdminUserId }
                );
        }


    }
}
