using System;
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

    public virtual DbSet<Models.ClotheColor> ClotheColors { get; set; }

    public virtual DbSet<Models.Color> Colors { get; set; }

    public virtual DbSet<Models.Outfit> Outfits { get; set; }

    public virtual DbSet<Models.OutfitClothe> OutfitClothes { get; set; }

    public virtual DbSet<Models.Type> Types { get; set; }

    public virtual DbSet<Models.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=WardrobeManager; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Clothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clothes__3214EC071B1EB008");

            entity.HasOne(d => d.Type).WithMany(p => p.Clothes).HasConstraintName("FK__Clothes__TypeId__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Clothes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clothes__UserId__403A8C7D");
        });

        modelBuilder.Entity<Models.ClotheColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClotheCo__3214EC07820B13CA");

            entity.HasOne(d => d.Clothe).WithMany(p => p.ClotheColors).HasConstraintName("FK__ClotheCol__Cloth__4AB81AF0");

            entity.HasOne(d => d.Color).WithMany(p => p.ClotheColors).HasConstraintName("FK__ClotheCol__Color__4BAC3F29");
        });

        modelBuilder.Entity<Models.Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07D540F6A1");
        });

        modelBuilder.Entity<Models.Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC078A555347");

            entity.HasOne(d => d.User).WithMany(p => p.Outfits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Outfits__UserId__3A81B327");
        });

        modelBuilder.Entity<Models.OutfitClothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutfitCl__3214EC0726E2D280");

            entity.HasOne(d => d.Clothe).WithMany(p => p.OutfitClothes).HasConstraintName("FK__OutfitClo__Cloth__47DBAE45");

            entity.HasOne(d => d.Outfit).WithMany(p => p.OutfitClothes).HasConstraintName("FK__OutfitClo__Outfi__46E78A0C");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Types__3214EC070B157E91");
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0787F8F38E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
