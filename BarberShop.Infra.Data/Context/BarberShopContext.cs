using System;
using System.Collections.Generic;
using BarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Data.Context;

public partial class BarberShopContext : DbContext
{
    public BarberShopContext()
    {
    }

    public BarberShopContext(DbContextOptions<BarberShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBarbershopInfo> TblBarbershopInfos { get; set; }

    public virtual DbSet<TblBeforeAfter> TblBeforeAfters { get; set; }

    public virtual DbSet<TblDiscountCode> TblDiscountCodes { get; set; }

    public virtual DbSet<TblHairStylist> TblHairStylists { get; set; }

    public virtual DbSet<TblHairStylistLevel> TblHairStylistLevels { get; set; }

    public virtual DbSet<TblPrice> TblPrices { get; set; }

    public virtual DbSet<TblReservation> TblReservations { get; set; }

    public virtual DbSet<TblService> TblServices { get; set; }

    public virtual DbSet<TblServicePriceRel> TblServicePriceRels { get; set; }

    public virtual DbSet<TblSuggestion> TblSuggestions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblWorkPhoto> TblWorkPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBarbershopInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblBarbe__3213E83F6E0234E6");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TblBeforeAfter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblBefor__3213E83FAD125F25");
        });

        modelBuilder.Entity<TblHairStylist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblHairS__3213E83FD7CF83D6");

            entity.HasOne(d => d.HairStylistLevel).WithMany(p => p.TblHairStylists).HasConstraintName("FK_TblHairStylists_TblHairStylistLevels1");
        });

        modelBuilder.Entity<TblHairStylistLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblHairS__3213E83FA3C6BC8C");
        });

        modelBuilder.Entity<TblPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblPrice__3213E83FA4E7D200");
        });

        modelBuilder.Entity<TblReservation>(entity =>
        {
            entity.HasOne(d => d.ServicePriceRel).WithMany(p => p.TblReservations)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TblReservation_TblServicePriceRels");

            entity.HasOne(d => d.User).WithMany(p => p.TblReservations)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TblReservation_TblUsers");
        });

        modelBuilder.Entity<TblService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblServi__3213E83F26D0962F");
        });

        modelBuilder.Entity<TblServicePriceRel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblServi__3213E83F72C9987B");

            entity.HasOne(d => d.HairStylist).WithMany(p => p.TblServicePriceRels)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblServicePriceRels_TblHairStylists");

            entity.HasOne(d => d.Service).WithMany(p => p.TblServicePriceRels)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblServicePriceRels_TblServices");
        });

        modelBuilder.Entity<TblSuggestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblSugge__3213E83F16289D30");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblUsers__3213E83F10259958");
        });

        modelBuilder.Entity<TblWorkPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblWorkP__3213E83F9C53EF76");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
