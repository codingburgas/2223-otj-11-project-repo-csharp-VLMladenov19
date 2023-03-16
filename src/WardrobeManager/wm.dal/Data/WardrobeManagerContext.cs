﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using wm.dal.Models;

namespace wm.dal.Data;

public partial class WardrobeManagerContext : DbContext
{
    public WardrobeManagerContext()
    {
    }

    public WardrobeManagerContext(DbContextOptions<WardrobeManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Models.Clothe> Clothes { get; set; }

    public virtual DbSet<Models.Color> Colors { get; set; }

    public virtual DbSet<Models.Outfit> Outfits { get; set; }

    public virtual DbSet<Models.Type> Types { get; set; }

    public virtual DbSet<Models.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=WardrobeManager; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Clothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clothes__3214EC07ED56A3B7");

            entity.HasOne(d => d.User).WithMany(p => p.Clothes).HasConstraintName("FK__Clothes__UserId__4E88ABD4");
        });

        modelBuilder.Entity<Models.Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC078CA232B0");
        });

        modelBuilder.Entity<Models.Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC0794F7430E");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Types__3214EC07B43CE622");
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0746A275D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
