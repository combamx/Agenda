using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Agenda.Models
{
    public partial class agendaContext : DbContext
    {
        public agendaContext()
        {
        }

        public agendaContext(DbContextOptions<agendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=agenda;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.Schedule)
                    .HasColumnType("datetime")
                    .HasColumnName("schedule");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Property");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DisabledAt)
                    .HasColumnType("datetime")
                    .HasColumnName("disabled_at");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasColumnName("answers");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Survey_Activity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
