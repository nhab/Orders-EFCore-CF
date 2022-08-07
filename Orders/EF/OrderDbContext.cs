using Microsoft.EntityFrameworkCore;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.EF
{
    public  class OrderDbContext:DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CLSBCU4\N;Initial Catalog=StoreDB;persist security info=True; Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.OrderDate)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailID);

                entity.HasIndex(e => e.OrderID);

                entity.Property(e => e.OrderDetailID).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderID).HasColumnName("OrderID");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderID);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID);

                entity.Property(e => e.OrderID).HasColumnName("OrderID");

                entity.Property(e => e.CustomerID).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
            });
        }
    }
}
