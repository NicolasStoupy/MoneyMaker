using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityModels;

public partial class MoneyContext : DbContext
{
    public MoneyContext()
    {
    }

    public MoneyContext(DbContextOptions<MoneyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Money;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Applicat__1788CCAC856AC3EA");

            entity.ToTable("ApplicationUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Forname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.BankAccountId).HasName("PK__BankAcco__4FC8E7416242F76C");

            entity.ToTable("BankAccount");

            entity.Property(e => e.BankAccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BankAccountID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.HasOne(d => d.Owner).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BankAccou__Owner__2B3F6F97");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("PK__Operatio__A4F5FC64440098B7");

            entity.ToTable("Operation");

            entity.Property(e => e.OperationId).HasColumnName("OperationID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.BankAccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BankAccountID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

            entity.HasOne(d => d.BankAccount).WithMany(p => p.Operations)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK__Operation__BankA__2E1BDC42");

            entity.HasOne(d => d.Period).WithMany(p => p.Operations)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__Perio__300424B4");

            entity.HasOne(d => d.Provider).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__Provi__2F10007B");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Period__E521BB36209F20A5");

            entity.ToTable("Period");

            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.PeriodeType)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__B54C689D02E022E2");

            entity.ToTable("Provider");

            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
