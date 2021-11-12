using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CrudMind.Data
{
    public partial class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=CustomerDb; trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Addresses_Customers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerDob)
                    .HasColumnType("date")
                    .HasColumnName("CustomerDOB");

                entity.Property(e => e.CustomerEmail).HasMaxLength(50);

                entity.Property(e => e.CustomerFirstName).HasMaxLength(50);

                entity.Property(e => e.CustomerGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerLastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
