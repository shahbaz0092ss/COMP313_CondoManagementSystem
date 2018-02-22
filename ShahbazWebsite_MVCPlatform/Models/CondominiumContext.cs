using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShahbazWebsite_MVCPlatform.Models
{
    public partial class CondominiumContext : DbContext
    {
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=comp313mvcdatabaseserver.database.windows.net;Initial Catalog=comp313MVCDatabase;Integrated Security=False;User ID=mudrak;Password=Password@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKING");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDetail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TimeFrom)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TimeTo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BOOKING__UserID__5535A963");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("MAINTENANCE");

                entity.Property(e => e.MaintenanceId).HasColumnName("MaintenanceID");

                entity.Property(e => e.Category)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MaintenanceDetail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Maintenance)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__MAINTENAN__UserI__5629CD9C");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("MESSAGES");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.DateTimeOfMessage).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SentBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SentTo)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("USERS");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
