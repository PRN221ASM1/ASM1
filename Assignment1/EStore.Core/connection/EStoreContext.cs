using EStore.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.connection
{
    public class EStoreContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=EStore;Integrated Security=True; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>(member =>
            {
                member.ToTable("Members");
                member.HasKey(member => member.MemberId);

            });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("Products");
                product.HasKey(product => product.ProductId);
                product.HasOne(product => product.Category)
                .WithMany(product => product.Products)
                .HasForeignKey(product => product.CategoryId);

                product.HasMany(p => p.OrderDetails)
                 .WithOne(p => p.Product)
                 .HasForeignKey(product => product.ProductId);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categories");
                category.HasKey(category => category.CategoryId);
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.ToTable("Orders");
                order.HasKey(order => order.OrderId);
                order.HasOne(order => order.Member)
                .WithMany(order => order.Orders)
                .HasForeignKey(order => order.MemberId).IsRequired();
                order.HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            });

            modelBuilder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.ToTable("OrderDetails");
                orderDetail.HasKey(orderDetail => orderDetail.OrderDetailId);
            });
        }

    }
}
