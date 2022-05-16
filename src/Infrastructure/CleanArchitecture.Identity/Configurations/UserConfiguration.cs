using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "421a1a2a-eae0-4893-af83-2eb89a4e9ff6",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "contact@evaristocuesta.com",
                    NormalizedEmail = "CONTACT@EVARISTOCUESTA.COM",
                    Name = "Evaristo",
                    SurName = "Cuesta",
                    PasswordHash = hasher.HashPassword(null, "changeme"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "73e3772e-4274-4333-8251-05f530885114",
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@evaristocuesta.com",
                    NormalizedEmail = "USER1@EVARISTOCUESTA.COM",
                    Name = "user1",
                    SurName = "user1",
                    PasswordHash = hasher.HashPassword(null, "changeme"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
