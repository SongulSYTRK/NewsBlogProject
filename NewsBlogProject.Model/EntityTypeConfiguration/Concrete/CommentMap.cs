using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class CommentMap:BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text)
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.HasOne(x => x.NewsCast)
                   .WithMany(x => x.Comment)
                   .HasForeignKey(x => x.NewsCastId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                 new Comment { Id=1, Text="beast", AppUserId=2, NewsCastId=3},
                 new Comment { Id = 3, Text = "interesting news", AppUserId = 1, NewsCastId =2}
                );
            base.Configure(builder);


        }
    }
}
