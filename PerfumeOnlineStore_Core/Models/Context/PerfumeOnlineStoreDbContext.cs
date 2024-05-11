using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Models.Entites;
using PerfumeOnlineStore_Core.Models.EntityConfigurationes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Models.Context
{
    public class PerfumeOnlineStoreDbContext : DbContext
    {
        public PerfumeOnlineStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserProductEntityTypeConfiguration()); 
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration()); 
            modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBrandsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSectionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityTypeConfiguration()); 
            modelBuilder.ApplyConfiguration(new OrderUserEntityTypeConfiguration()); 

        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageProduct> PackageProductes { get; set; }
        public virtual DbSet<Product> Productes { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductSection> ProductSections { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<PromoCode> PromoCodes { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<OrderUser> OrderUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }        

    }
}
