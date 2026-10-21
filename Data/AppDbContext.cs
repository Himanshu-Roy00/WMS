
using Microsoft.EntityFrameworkCore;
using WMS.Models;

namespace WMS.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<StockIn> StockIns { get; set; }
		public DbSet<StockOut> StockOuts { get; set; }
		public DbSet<ProductTransfer> ProductTransfers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<UOM> UOMs { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductTransferDetail> ProductTransferDetails { get; set; }


        // ✅ Ye add karo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ProductTransferDetail ka cascade delete band karo
            modelBuilder.Entity<ProductTransferDetail>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // ✅ Fix

            modelBuilder.Entity<ProductTransferDetail>()
               .HasOne(d => d.ProductTransfer)
               .WithMany(t => t.Details)
               .HasForeignKey(d => d.ProductTransferId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}