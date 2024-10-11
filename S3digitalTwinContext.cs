using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;


namespace addDataToDB;

public partial class S3digitalTwinContext : DbContext
{
    public S3digitalTwinContext()
    {
    }

    public S3digitalTwinContext(DbContextOptions<S3digitalTwinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestPattern> TestPatterns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Password123!;database=S3DigitalTwin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.5.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TestPattern>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TestPattern");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ChunkId)
                .HasColumnType("int(11)")
                .HasColumnName("ChunkID");
            entity.Property(e => e.CoordX).HasColumnName("coordX");
            entity.Property(e => e.CoordY).HasColumnName("coordY");
            entity.Property(e => e.CoordZ).HasColumnName("coordZ");
            entity.Property(e => e.GripperOpen).HasColumnName("gripperOpen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
