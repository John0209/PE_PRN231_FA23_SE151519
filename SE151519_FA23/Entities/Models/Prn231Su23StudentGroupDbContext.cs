using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities.Models;

public partial class Prn231Su23StudentGroupDbContext : DbContext
{
    public Prn231Su23StudentGroupDbContext()
    {
    }

    public Prn231Su23StudentGroupDbContext(DbContextOptions<Prn231Su23StudentGroupDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(GetConnectionString());
    private string GetConnectionString()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        return configuration.GetConnectionString("DBSQL");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC074ECD67D3");

            entity.ToTable("Student");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(250);

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Student__GroupId__3C69FB99");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentG__3214EC079A165EC9");

            entity.ToTable("StudentGroup");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.GroupName).HasMaxLength(250);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07E10F1340");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.Username, "UQ__UserRole__536C85E400DD19FD").IsUnique();

            entity.Property(e => e.Passphrase)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserRole1).HasColumnName("UserRole");
            entity.Property(e => e.Username).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
