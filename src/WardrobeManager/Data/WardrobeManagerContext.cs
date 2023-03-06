using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WardrobeManager.Models;

namespace WardrobeManager.Data;

public partial class WardrobeManagerContext : DbContext
{
    public WardrobeManagerContext()
    {
    }

    public WardrobeManagerContext(DbContextOptions<WardrobeManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clothe> Clothes { get; set; }

    public virtual DbSet<ClothesColor> ClothesColors { get; set; }

    public virtual DbSet<ClothesLibrary> ClothesLibraries { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Outfit> Outfits { get; set; }

    public virtual DbSet<OutfitsClothe> OutfitsClothes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersOutfit> UsersOutfits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=WardrobeManager; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clothe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clothes__3214EC07AA308245");
        });

        modelBuilder.Entity<ClothesColor>(entity =>
        {
            entity.HasOne(d => d.Clothe).WithMany().HasConstraintName("FK__ClothesCo__Cloth__1F63A897");

            entity.HasOne(d => d.Color).WithMany().HasConstraintName("FK__ClothesCo__Color__2057CCD0");
        });

        modelBuilder.Entity<ClothesLibrary>(entity =>
        {
            entity.HasOne(d => d.Clothe).WithMany().HasConstraintName("FK__ClothesLi__Cloth__22401542");

            entity.HasOne(d => d.Library).WithMany().HasConstraintName("FK__ClothesLi__Libra__2334397B");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC0711B33BED");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Librarie__3214EC07A5AB9E54");
        });

        modelBuilder.Entity<Outfit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outfits__3214EC07E9A2EE28");
        });

        modelBuilder.Entity<OutfitsClothe>(entity =>
        {
            entity.HasOne(d => d.Clothe).WithMany().HasConstraintName("FK__OutfitsCl__Cloth__1D7B6025");

            entity.HasOne(d => d.Outfit).WithMany().HasConstraintName("FK__OutfitsCl__Outfi__1C873BEC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC073720F377");

            entity.HasOne(d => d.Library).WithMany(p => p.Users).HasConstraintName("FK__Users__LibraryId__1209AD79");
        });

        modelBuilder.Entity<UsersOutfit>(entity =>
        {
            entity.HasOne(d => d.Outfit).WithMany().HasConstraintName("FK__UsersOutf__Outfi__1A9EF37A");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__UsersOutf__UserI__19AACF41");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
