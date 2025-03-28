using System;
using Microsoft.EntityFrameworkCore;

namespace MVCusingEFCoreDBFirst.Models
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Se recomienda configurar la cadena de conexión en appsettings.json
                object value = optionsBuilder.UseSqlServer("Server=LAPTOP-6P5NK25R\\SQLSERVER2022DEV;Database=Company; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Employee");
                entity.ToTable("Employee");

                entity.Property(e => e.Department)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.FirstName)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.LastName)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Salary)
                      .HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
