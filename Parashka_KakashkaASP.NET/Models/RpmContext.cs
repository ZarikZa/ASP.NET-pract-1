using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parashka_KakashkaASP.NET.Models;

public partial class RpmContext : DbContext
{
    public RpmContext()
    {
    }

    public RpmContext(DbContextOptions<RpmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CountryProizvodstva> CountryProizvodstvas { get; set; }

    public virtual DbSet<TypeOplati> TypeOplatis { get; set; }

    public virtual DbSet<UniBill> UniBills { get; set; }

    public virtual DbSet<Unitaz> Unitazs { get; set; }

    public virtual DbSet<UnitazType> UnitazTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G9HLV3B\\SQLEXPRESS;Initial Catalog=RPM;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bills__CF6E7D4323769274");

            entity.Property(e => e.BillId).HasColumnName("Bill_ID");
            entity.Property(e => e.DateBill)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FkClient).HasColumnName("FK_Client");
            entity.Property(e => e.FkTypeOplati).HasColumnName("FK_TypeOplati");
            entity.Property(e => e.PriceBill).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.FkClientNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.FkClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bills__FK_Client__48CFD27E");

            entity.HasOne(d => d.FkTypeOplatiNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.FkTypeOplati)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bills__FK_TypeOp__47DBAE45");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__75A5D718104635CE");

            entity.HasIndex(e => e.Loginn, "UQ__Clients__D00D063FE20C0B0A").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.ClientMiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Loginn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CountryProizvodstva>(entity =>
        {
            entity.HasKey(e => e.CountryProizvodstvaId).HasName("PK__CountryP__13DBAA3297C7EA06");

            entity.HasIndex(e => e.CountryProizvodstva1, "UQ__CountryP__E0AD09536539C819").IsUnique();

            entity.Property(e => e.CountryProizvodstvaId).HasColumnName("CountryProizvodstva_ID");
            entity.Property(e => e.CountryProizvodstva1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CountryProizvodstva");
        });

        modelBuilder.Entity<TypeOplati>(entity =>
        {
            entity.HasKey(e => e.TypeOplatiId).HasName("PK__TypeOpla__7C35DD2B70DD7ED9");

            entity.HasIndex(e => e.TypeOplati1, "UQ__TypeOpla__01578CADD76C80D8").IsUnique();

            entity.Property(e => e.TypeOplatiId).HasColumnName("TypeOplati_ID");
            entity.Property(e => e.TypeOplati1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TypeOplati");
        });

        modelBuilder.Entity<UniBill>(entity =>
        {
            entity.HasKey(e => e.UniBillId).HasName("PK__UniBill__B686BD7828CD8DF4");

            entity.ToTable("UniBill");

            entity.Property(e => e.UniBillId).HasColumnName("UniBill_ID");
            entity.Property(e => e.FkBill).HasColumnName("FK_Bill");
            entity.Property(e => e.FkUnitaz).HasColumnName("FK_Unitaz");

            entity.HasOne(d => d.FkBillNavigation).WithMany(p => p.UniBills)
                .HasForeignKey(d => d.FkBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UniBill__FK_Bill__4CA06362");

            entity.HasOne(d => d.FkUnitazNavigation).WithMany(p => p.UniBills)
                .HasForeignKey(d => d.FkUnitaz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UniBill__FK_Unit__4BAC3F29");
        });

        modelBuilder.Entity<Unitaz>(entity =>
        {
            entity.HasKey(e => e.UnitazId).HasName("PK__Unitazs__E9C5D7039BD48968");

            entity.HasIndex(e => e.UnitazName, "UQ__Unitazs__E7AD3FF57E74ED83").IsUnique();

            entity.Property(e => e.UnitazId).HasColumnName("Unitaz_ID");
            entity.Property(e => e.FkCountryProizvodstva).HasColumnName("FK_CountryProizvodstva");
            entity.Property(e => e.FkUnitazType).HasColumnName("FK_UnitazType");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Infa).HasColumnType("text");
            entity.Property(e => e.UnitazName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UnitazPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.FkCountryProizvodstvaNavigation).WithMany(p => p.Unitazs)
                .HasForeignKey(d => d.FkCountryProizvodstva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Unitazs__FK_Coun__3F466844");

            entity.HasOne(d => d.FkUnitazTypeNavigation).WithMany(p => p.Unitazs)
                .HasForeignKey(d => d.FkUnitazType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Unitazs__FK_Unit__3E52440B");
        });

        modelBuilder.Entity<UnitazType>(entity =>
        {
            entity.HasKey(e => e.UnitazTypeId).HasName("PK__UnitazTy__BD619D1B3F9B2A64");

            entity.HasIndex(e => e.UnitazType1, "UQ__UnitazTy__0F6D55EEB0F27BF7").IsUnique();

            entity.Property(e => e.UnitazTypeId).HasColumnName("UnitazType_ID");
            entity.Property(e => e.UnitazType1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("UnitazType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
