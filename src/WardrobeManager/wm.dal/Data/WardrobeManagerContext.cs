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
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=WardrobeManager;Integrated Security=True;Trust Server Certificate=True");
            
        }
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Clothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clothes__3214EC07B1BC9473");

            entity.HasOne(d => d.Type).WithMany(p => p.Clothes).HasConstraintName("FK__Clothes__TypeId__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Clothes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clothes__UserId__403A8C7D");
        });

        modelBuilder.Entity<Models.ClotheColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClotheCo__3214EC07C12090E7");

            entity.HasOne(d => d.Clothe).WithMany(p => p.ClotheColors).HasConstraintName("FK__ClotheCol__Cloth__4AB81AF0");

            entity.HasOne(d => d.Color).WithMany(p => p.ClotheColors).HasConstraintName("FK__ClotheCol__Color__4BAC3F29");
        });

        modelBuilder.Entity<Models.Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07CB38827C");
        });

        modelBuilder.Entity<Models.Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC0714BA65DF");

            entity.HasOne(d => d.User).WithMany(p => p.Outfits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Outfits__UserId__3A81B327");
        });

        modelBuilder.Entity<Models.OutfitClothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutfitCl__3214EC07ECDC0ED1");

            entity.HasOne(d => d.Clothe).WithMany(p => p.OutfitClothes).HasConstraintName("FK__OutfitClo__Cloth__47DBAE45");

            entity.HasOne(d => d.Outfit).WithMany(p => p.OutfitClothes).HasConstraintName("FK__OutfitClo__Outfi__46E78A0C");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Types__3214EC0739A6036B");
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07CD51B92A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
