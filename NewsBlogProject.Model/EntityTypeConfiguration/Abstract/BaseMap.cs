
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.EntityTypeConfiguration.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        //if you dont install EFCore, you mustnt namespace of IentityTypeConfiguration
        public virtual void Configure(EntityTypeBuilder<T> builder) //Dont forget VİRTUAL
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).IsRequired(false);
            builder.Property(x => x.CreateComputerName).IsRequired(false);
            builder.Property(x => x.CreateIp).IsRequired(false);
            builder.Property(x => x.DeleteDate).IsRequired(false);
            builder.Property(x => x.DeleteComputerName).IsRequired(false);
            builder.Property(x => x.DeleteIp).IsRequired(false);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.UpdateComputerName).IsRequired(false);
            builder.Property(x => x.UpdateIp).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
        }

    }
}
