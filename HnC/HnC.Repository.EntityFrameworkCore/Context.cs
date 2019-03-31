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

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.OwnsMany(e => e.OrderItems);
            });
            
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.OrderId,
                    e.ItemId
                });

                entity.Property(e => e.ItemId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.OrderId).IsRequired();

                entity.HasOne(x => x.Order)
                    .WithMany(y => y.OrderItems)
                    .HasForeignKey(z => z.OrderId );
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
