using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.EntityTypeConfiguration.Concrete
{
   public  class CategoryMap:BaseMap<Category>

    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired(true);
            base.Configure(builder);
        }
    }
}
