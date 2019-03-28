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

        public virtual DbSet<Basket> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ItemId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
