using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Housing.Models;

#nullable disable

namespace Housing.Data
{
    public partial class HousingDbContext : DbContext
    {
        public HousingDbContext()
        {
        }

        public HousingDbContext(DbContextOptions<HousingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<ResidentTicket> ResidentTickets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Housing;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__Resident__44F5EC957B1AD751");

                entity.Property(e => e.UnitId).ValueGeneratedNever();

                entity.Property(e => e.CellNumber).IsUnicode(false);

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            modelBuilder.Entity<ResidentTicket>(entity =>
            {
                entity.Property(e => e.TicketStatus).IsUnicode(false);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.ResidentTickets)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resident___Ticke__36B12243");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.ResidentTickets)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resident___UnitI__35BCFE0A");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Complaint).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
