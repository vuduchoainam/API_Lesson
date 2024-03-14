using Microsoft.EntityFrameworkCore;

namespace Lessonapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.NgayDH).HasDefaultValue(DateTime.UtcNow);

            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");

            });
        }
    }
}
