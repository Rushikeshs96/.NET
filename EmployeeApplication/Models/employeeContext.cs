using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeApplication.Models
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
        {
        }

        public employeeContext(DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Emp> Emps { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=employee;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.StateId, "StateId_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City1)
                    .HasMaxLength(45)
                    .HasColumnName("City");

                entity.HasOne(d => d.State);
                    //.WithMany(p => p.Cities)
                    //.HasForeignKey(d => d.StateId)
                    //.HasConstraintName("StateId");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("emp");

              
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Fname)
                    .HasMaxLength(45)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(45)
                    .HasColumnName("LName");

                entity.Property(e => e.Password).HasMaxLength(45);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.State1)
                    .HasMaxLength(45)
                    .HasColumnName("State");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
