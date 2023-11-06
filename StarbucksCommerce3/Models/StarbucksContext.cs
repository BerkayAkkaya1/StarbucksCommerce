using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StarbucksCommerce3.Models;

public partial class StarbucksContext : DbContext
{
    public StarbucksContext()
    {
    }

    public StarbucksContext(DbContextOptions<StarbucksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<Header> Headers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Refund> Refunds { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-N5JHVVH;Database=Starbucks;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressDescription).HasMaxLength(150);
            entity.Property(e => e.AddressName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Address_Member");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Kategori");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK_Favorite");

            entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
            entity.Property(e => e.FavoriteDate).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Member).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Member");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Product");
        });

        modelBuilder.Entity<Footer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Footer");

            entity.Property(e => e.FooterLink)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FooterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Header>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Header");

            entity.Property(e => e.HeaderLink)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HeaderName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK_Member");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.MemberMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.OrderPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Member");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.Property(e => e.PointId)
                .ValueGeneratedNever()
                .HasColumnName("PointID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Member).WithMany(p => p.Points)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Points_Members");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Refund>(entity =>
        {
            entity.HasKey(e => e.ReturnId);

            entity.Property(e => e.ReturnId)
                .ValueGeneratedNever()
                .HasColumnName("ReturnID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ReturnDescription)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Member).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refunds_Members");

            entity.HasOne(d => d.Order).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refunds_Orders");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.GiftTokenId);

            entity.Property(e => e.GiftTokenId)
                .ValueGeneratedNever()
                .HasColumnName("GiftTokenID");
            entity.Property(e => e.ExpDate).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.TokenAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Member).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_Tokens");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
