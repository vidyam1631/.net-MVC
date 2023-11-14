using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_DBFirstDemo.Models
{
    public partial class db_classDemoContext : DbContext
    {
        public db_classDemoContext()
        {
        }

        public db_classDemoContext(DbContextOptions<db_classDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=db_classDemo; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__catagory__17B6DD06655F7F20");

                entity.ToTable("catagory");

                entity.HasIndex(e => e.CatCode, "UQ__catagory__76CFC30EE0FDB86A")
                    .IsUnique();

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.CatCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("catCode");

                entity.Property(e => e.CatDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("catDesc");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__product__62029590BEABEBD9");

                entity.ToTable("product");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__product__catId__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
