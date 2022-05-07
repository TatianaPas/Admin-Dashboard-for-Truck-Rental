using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewDesignTrial.Models.DB
{
    public partial class DAD_TatianaContext : DbContext
    {
        public DAD_TatianaContext()
        {
        }

        public DAD_TatianaContext(DbContextOptions<DAD_TatianaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IndividualTruck> IndividualTrucks { get; set; } = null!;
        public virtual DbSet<TruckCustomer> TruckCustomers { get; set; } = null!;
        public virtual DbSet<TruckEmployee> TruckEmployees { get; set; } = null!;
        public virtual DbSet<TruckFeature> TruckFeatures { get; set; } = null!;
        public virtual DbSet<TruckModel> TruckModels { get; set; } = null!;
        public virtual DbSet<TruckPerson> TruckPeople { get; set; } = null!;
        public virtual DbSet<TruckRental> TruckRentals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=citizen.manukautech.info,6306;Initial Catalog=DAD_Tatiana;Persist Security Info=True;User ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndividualTruck>(entity =>
            {
                entity.HasKey(e => e.TruckId);

                entity.ToTable("IndividualTruck");

                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.Property(e => e.AdvanceDepositRequired).HasColumnType("money");

                entity.Property(e => e.Colour)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRentalPrice).HasColumnType("money");

                entity.Property(e => e.DateImported).HasColumnType("date");

                entity.Property(e => e.FuelType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationExpiryDate).HasColumnType("date");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transmission)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TruckModelId).HasColumnName("TruckModelID");

                entity.Property(e => e.WofexpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("WOFExpiryDate");

                entity.HasOne(d => d.TruckModel)
                    .WithMany(p => p.IndividualTrucks)
                    .HasForeignKey(d => d.TruckModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IndividualTruck_TruckModel");

                entity.HasMany(d => d.Features)
                    .WithMany(p => p.Trucks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TruckFeatureAssociation",
                        l => l.HasOne<TruckFeature>().WithMany().HasForeignKey("FeatureId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Truck_Feature_Association_TruckFeature"),
                        r => r.HasOne<IndividualTruck>().WithMany().HasForeignKey("TruckId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Truck_Feature_Association_IndividualTruck"),
                        j =>
                        {
                            j.HasKey("TruckId", "FeatureId");

                            j.ToTable("Truck_Feature_Association");

                            j.IndexerProperty<int>("TruckId").HasColumnName("TruckID");

                            j.IndexerProperty<int>("FeatureId").HasColumnName("FeatureID");
                        });
            });

            modelBuilder.Entity<TruckCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("TruckCustomer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.LicenseExpiryDate).HasColumnType("date");

                entity.Property(e => e.LicenseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.TruckCustomer)
                    .HasForeignKey<TruckCustomer>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckCustomer_TruckPerson");
            });

            modelBuilder.Entity<TruckEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("TruckEmployee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.OfficeAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneExtensionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.TruckEmployee)
                    .HasForeignKey<TruckEmployee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckEmployee_TruckPerson");
            });

            modelBuilder.Entity<TruckFeature>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.ToTable("TruckFeature");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TruckModel>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("TruckModel");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TruckPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("TruckPerson");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TruckRental>(entity =>
            {
                entity.HasKey(e => e.RentalId);

                entity.ToTable("TruckRental");

                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RentDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.ReturnDueDate).HasColumnType("date");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.TruckId).HasColumnName("TruckID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TruckRentals)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckRental_TruckCustomer");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.TruckRentals)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckRental_IndividualTruck");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
