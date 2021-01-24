using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(100000);
        }

        

        public virtual DbSet<Ots> Ots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseSqlServer("Server=DESKTOP-G7S5ICC\\SQLEXPRESS;Database=Prueba;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ots>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Contractor)
                    .IsRequired()
                    .HasColumnName("contractor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Costcenter).HasColumnName("costcenter");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idteam).HasColumnName("idteam");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasColumnName("invoice")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LaborPrice)
                    .HasColumnName("labor_price")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.MaterialPrice)
                    .HasColumnName("material_price")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("project_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.StateProject)
                    .IsRequired()
                    .HasColumnName("state_Project")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
