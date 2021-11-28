using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class LikeMap:BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(x => x.NewsCast)
                  .WithMany(x => x.Like)
                  .HasForeignKey(x => x.NewsCastId)
                  .OnDelete(DeleteBehavior.Restrict);
         builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
           //seeddata
            builder.HasData
                (
                 new Like { Id=2, NewsCastId=1, AppUserId=2},
                 new Like { Id = 1, NewsCastId = 3, AppUserId = 1 }

                );
            base.Configure(builder);
        }
    }
}
