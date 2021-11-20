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
            base.Configure(builder);
        }
    }
}
