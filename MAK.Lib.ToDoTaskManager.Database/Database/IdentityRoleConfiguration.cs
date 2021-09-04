using Constants;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(items);
        }

        private static int id = 0;
        private static readonly List<IdentityRole> items = new()
        {
            new IdentityRole
            {
                Id = (++id).ToString(),
                Name = IdentityRoleName.ADMIN,
                NormalizedName = IdentityRoleName.ADMIN_NORMALIZED
            },
            new IdentityRole
            {
                Id = (++id).ToString(),
                Name = IdentityRoleName.SUPER_ADMIN,
                NormalizedName = IdentityRoleName.SUPER_ADMIN_NORMALIZED
            },
            new IdentityRole
            {
                Id = (++id).ToString(),
                Name = IdentityRoleName.EDITOR,
                NormalizedName = IdentityRoleName.EDITOR_NORMALIZED
            },
            new IdentityRole
            {
                Id = (++id).ToString(),
                Name = IdentityRoleName.REGULAR_USER,
                NormalizedName = IdentityRoleName.REGULAR_USER_NORMALIZED
            }
        };
    }
}
