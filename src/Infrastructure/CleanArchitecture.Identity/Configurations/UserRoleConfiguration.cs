using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                { 
                    UserId = "421a1a2a-eae0-4893-af83-2eb89a4e9ff6",
                    RoleId = "491b8d1f-c5aa-4136-a24f-d865d3329d6b"
                },
                new IdentityUserRole<string>
                {
                    UserId = "73e3772e-4274-4333-8251-05f530885114",
                    RoleId = "34018e52-c0c8-4da3-ae5b-a1da72108a21"
                }
            );
        }
    }
}
