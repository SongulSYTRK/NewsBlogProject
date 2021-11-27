using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.EntityTypeConfiguration.Concrete
{
 public   class NewsCastMap:BaseMap<NewsCast>
    {
        public override void Configure(EntityTypeBuilder<NewsCast> builder)
        {
            builder.Property(x => x.Title)
                   .HasMaxLength(70)
                   .IsRequired(true);


            builder.Property(x => x.Content)
                   .HasMaxLength(1000)
                   .IsRequired(true);


            builder.Property(x => x.Image)
                   .HasMaxLength(200)
                   .IsRequired(true);



            builder.HasOne(x => x.Category)
                   .WithMany(x => x.NewsCasts)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppUser)
                    .WithMany(x => x.NewsCasts)
                    .HasForeignKey(x => x.AppUserId)
                    .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
