using HnC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace HnC.Repository.EntityFrameworkCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context() : base()
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName).IsRequired();
                entity.OwnsMany(e => e.BasketItems);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ItemId).IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(e => e.BasketItems)
                    .HasForeignKey(e => e.UserId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
