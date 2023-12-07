using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Entities;

namespace Week11_Assignment.Persistence.Configurations
{
    public class DirectorMoviesConfiguration : IEntityTypeConfiguration<DirectorMovies> 
    {
       
        public void Configure(EntityTypeBuilder<DirectorMovies> builder)
        {
            builder.HasKey(dm => new { dm.DirectorId, dm.MovieId });
            
            builder.HasOne(dm => dm.Director)
                .WithMany(x => x.DirectorMovies)
                .HasForeignKey(dm => dm.DirectorId);

            builder.HasOne(dm => dm.Movie)
                .WithMany(x => x.DirectorMovies)
                .HasForeignKey(dm => dm.MovieId);

            builder.ToTable("DirectorMovies");

        }
    }
}
