using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Persistence.Domain.Entities;

namespace Week11_Assignment.Persistence.Infrastructure.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure (EntityTypeBuilder<Movie> builder)
        {
            // Id - PrimaryKey
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Title
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100);

            // Release Year
            builder.Property(x => x.ReleaseYear).IsRequired();


            // Genre
            builder.Property(x => x.Genre).IsRequired();

            // Common Fields

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

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();

            // Relationships

            // DirectorId - Foreign Key
            //builder.Property(x => x.DirectorId).IsRequired();

            //builder.HasOne(x => x.Director)
            //    .WithMany(d => d.Movies)
            //    .HasForeignKey(x => x.DirectorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Movies");
        }

    }
}
