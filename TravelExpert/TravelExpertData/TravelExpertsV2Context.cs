using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class TravelExpertsV2Context : DbContext
    {
        public TravelExpertsV2Context()
        {
        }

        public TravelExpertsV2Context(DbContextOptions<TravelExpertsV2Context> options)
            : base(options)
        {
        }

        public static string stringConnection = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TravelExpertsV2;Integrated Security=True";

        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingProduct> BookingProduct { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductSupplier> ProductSupplier { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(stringConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Agent)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK__Agent__AgencyId__4E88ABD4");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("aaaaaBooking_PK")
                    .IsClustered(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__ClassId__4D94879B");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Booking__Custome__534D60F1");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__Booking__Package__5441852A");
            });

            modelBuilder.Entity<BookingProduct>(entity =>
            {
                entity.HasKey(e => e.Bpid)
                    .HasName("PK_BPID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingProduct)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingPr__Booki__5EBF139D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BookingProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingPr__Produ__5DCAEF64");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("aaaaaClass_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.CreditCardId)
                    .HasName("aaaaaCreditCard_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerCreditCard");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CreditCar__Custo__4CA06362");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("aaaaaCustomer_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.AgentId)
                    .HasName("EmployeesCustomer");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK__Customer__AgentI__4BAC3F29");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("aaaaaPackage_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("aaaaaProduct_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");
            });

            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSupplier)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductSu__Produ__6477ECF3");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductSupplier)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductSu__Suppl__656C112C");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("aaaaaSupplier_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.SupplierId)
                    .HasName("SupplierId");

                entity.Property(e => e.SupplierId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
