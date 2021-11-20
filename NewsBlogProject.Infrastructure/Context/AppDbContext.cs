using Microsoft.EntityFrameworkCore;
using NewsBlogProject.Infrastructure.Utilities;
using NewsBlogProject.Model.Entities.Abstract;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.EntityTypeConfiguration.Concrete;
using NewsBlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsBlogProject.Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        //you should add NewsBlogProject.Model to reference .
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<NewsCast> NewsCasts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }


        //you added entityTypeconfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new NewsCastMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new LikeMap());

            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {

            var ModifiedEntities = ChangeTracker.Entries()
                                                .Where(x => x.State == EntityState.Added || 
                                                            x.State == EntityState.Modified || 
                                                            x.State == EntityState.Deleted)
                                                .ToList();

            string computerName = Environment.MachineName;
            string ipAddress = RemoteIpAdress.IpAddress;
            DateTime date = DateTime.Now;

            foreach (var item in ModifiedEntities)
            {
                BaseEntity entity = item.Entity as BaseEntity;
                if (item != null)
                {
                    switch (item.State)
                    {

                        case EntityState.Deleted:
                            entity.DeleteComputerName = computerName;
                            entity.DeleteDate = date;
                            entity.DeleteIp = ipAddress;
                            entity.Status = Status.Passive;
                            break;
                        case EntityState.Modified:
                            entity.UpdateComputerName = computerName;
                            entity.UpdateDate = date;
                            entity.UpdateIp = ipAddress;
                            entity.Status = Status.Modified;
                            break;
                        case EntityState.Added:
                            entity.CreateComputerName = computerName;
                            entity.CreateDate = date;
                            entity.CreateIp = ipAddress;
                            entity.Status = Status.Active;
                            break;

                    }

                }
            }
            return base.SaveChanges();
        }
    }
}
