using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TariffComparison.Models
{
    public partial class ComparisonTariffDBContext : DbContext
    {
        public ComparisonTariffDBContext()
        {
        }

        public ComparisonTariffDBContext(DbContextOptions<ComparisonTariffDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0BBCI3J; Initial Catalog = ComparisonTariffDB; user Id = Raheleh; Password = Sh091023$#;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Productid).ValueGeneratedNever();

                entity.Property(e => e.Tariffname).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
