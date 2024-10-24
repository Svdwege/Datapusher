﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace addDataToDB.DB;

public partial class S3DigitalTwinContext : DbContext
{
    public S3DigitalTwinContext()
    {
    }

    public S3DigitalTwinContext(DbContextOptions<S3DigitalTwinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestPattern> TestPatterns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Password123!;database=S3DigitalTwin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.5.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TestPattern>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
