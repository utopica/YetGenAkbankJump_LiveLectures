﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week11_Assignment.Persistence.Domain.Identity;

namespace Week11_Assignment.Persistence.Infrastructure.Configurations.Identity
{
    public class UserSettingConfiguration:IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            //Relationship
            builder.HasOne<User>(x => x.User)
                .WithOne(u => u.UserSetting)
                .HasForeignKey<UserSetting>(us => us.UserId);


            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            // LastModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            builder.ToTable("UserSettings");
        }
    }
}
