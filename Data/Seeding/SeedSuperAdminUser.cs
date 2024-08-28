using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using virtual_ex.Models;

namespace virtual_ex.Data.Seeding
{
    public class SeedSuperAdminUser
    {


        public readonly UserModel superAdminUser = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = "pipeloluwapapic@yahoo.com",
            UserName = "VirtualEXAdmin"
        };

        private readonly string superAdminPassword;
        private readonly PasswordHasher<UserModel> passwordHasher;



        public SeedSuperAdminUser()
        {
            passwordHasher = new PasswordHasher<UserModel>();
            superAdminPassword = passwordHasher.HashPassword(superAdminUser, "password");
        }



        public void SeedSuperAdminUserFunction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData
                (
                    new UserModel()
                    {
                        Id = superAdminUser.Id,
                        Email = superAdminUser.Email,
                        NormalizedEmail = superAdminUser!.Email!.ToUpper(),
                        UserName = superAdminUser.UserName,
                        NormalizedUserName = superAdminUser!.UserName!.ToUpper(),
                        PasswordHash = superAdminPassword,
                    }
                );


        }



    }
}
