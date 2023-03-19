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

    public virtual DbSet<Models.ClothesColor> ClothesColors { get; set; }

    public virtual DbSet<Models.Color> Colors { get; set; }

    public virtual DbSet<Models.Outfit> Outfits { get; set; }

    public virtual DbSet<Models.OutfitsClothe> OutfitsClothes { get; set; }

    public virtual DbSet<Models.Type> Types { get; set; }

    public virtual DbSet<Models.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=WardrobeManager; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Clothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clothes__3214EC07660B54A2");

            entity.HasOne(d => d.Type).WithMany(p => p.Clothes).HasConstraintName("FK__Clothes__TypeId__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.Clothes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clothes__UserId__3F466844");
        });

        modelBuilder.Entity<Models.ClothesColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClothesC__3214EC073731B2C8");

            entity.HasOne(d => d.Clothe).WithMany(p => p.ClothesColors).HasConstraintName("FK__ClothesCo__Cloth__48CFD27E");

            entity.HasOne(d => d.Color).WithMany(p => p.ClothesColors).HasConstraintName("FK__ClothesCo__Color__49C3F6B7");
        });

        modelBuilder.Entity<Models.Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07A537D872");
        });

        modelBuilder.Entity<Models.Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC078A733504");

            entity.HasOne(d => d.User).WithMany(p => p.Outfits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Outfits__UserId__3A81B327");
        });

        modelBuilder.Entity<Models.OutfitsClothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutfitsC__3214EC07406AE2A7");

            entity.HasOne(d => d.Clothe).WithMany(p => p.OutfitsClothes).HasConstraintName("FK__OutfitsCl__Cloth__45F365D3");

            entity.HasOne(d => d.Outfit).WithMany(p => p.OutfitsClothes).HasConstraintName("FK__OutfitsCl__Outfi__44FF419A");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Types__3214EC075E86F894");
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC074453D081");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
