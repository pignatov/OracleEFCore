using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OracleEFCore
{
    public partial class NhifEessiContext : DbContext
    {
        public NhifEessiContext()
        {
        }

        public NhifEessiContext(DbContextOptions<NhifEessiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ehic> Ehic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=nhifeessi;Password=nhifeessi;Data Source=192.168.5.109:1521/DB11G;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:DefaultSchema", "NHIFEESSI");

            modelBuilder.Entity<Ehic>(entity =>
            {
                entity.ToTable("EHIC");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_EHIC")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .UseOracleIdentityColumn();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR2(200)");

                entity.Property(e => e.IdcardIssueDate)
                    .HasColumnName("IDCardIssueDate")
                    .HasColumnType("DATE");

                entity.Property(e => e.IdcardNo)
                    .IsRequired()
                    .HasColumnName("IDCardNo")
                    .HasColumnType("NVARCHAR2(100)");

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasColumnName("PIN")
                    .HasColumnType("NVARCHAR2(10)");
            });

            modelBuilder.HasSequence("EHIC_SEQ");
        }
    }
}
