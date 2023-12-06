using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10_1.Domain.Entities;
using Week10_1.Domain.Identity;

namespace Week10_1.Persistence.Configurations.Identity
{
    public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public UserSetting Id { get; set; }

        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            // Relationships

            builder.HasOne<User>(x => x.User)
                .WithOne(u => u.UserSetting)
                .HasForeignKey<UserSetting>(u => u.UserId);




            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            // LastModifiedOn
            builder.Property(x => x.LastModifiedOn).IsRequired(false);

            builder.ToTable("UserSettings");
        }
    }
}
