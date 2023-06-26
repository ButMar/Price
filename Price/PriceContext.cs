using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Price;

public partial class PriceContext : DbContext
{
    public PriceContext()
    {
    }

    public PriceContext(DbContextOptions<PriceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Price> Prices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=marynapc;Database=price;Integrated Security=True;Trusted_Connection=True;User Id=user1; Password=sa; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Price>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Price");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price1).HasColumnName("price1");
            entity.Property(e => e.Price100).HasColumnName("price100");
            entity.Property(e => e.Price20).HasColumnName("price20");
            entity.Property(e => e.PriceId).HasColumnName("price_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
