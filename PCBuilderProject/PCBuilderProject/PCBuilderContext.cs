﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PCBuilderProject
{
    public partial class PCBuilderContext : DbContext
    {
        public PCBuilderContext()
        {
        }

        public PCBuilderContext(DbContextOptions<PCBuilderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GraphicsCardTable> GraphicsCardTables { get; set; }
        public virtual DbSet<MotherboardTable> MotherboardTables { get; set; }
        public virtual DbSet<ProcessorTable> ProcessorTables { get; set; }
        public virtual DbSet<RamTable> RamTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PCBuilder;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GraphicsCardTable>(entity =>
            {
                entity.HasKey(e => e.Gcid)
                    .HasName("PK__Graphics__5933779370DF4731");

                entity.ToTable("GraphicsCard_Table");

                entity.Property(e => e.Gcid).HasColumnName("GCID");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vram).HasColumnName("VRAM");
            });

            modelBuilder.Entity<MotherboardTable>(entity =>
            {
                entity.HasKey(e => e.Mbid)
                    .HasName("PK__Motherbo__606143697168D529");

                entity.ToTable("Motherboard_Table");

                entity.Property(e => e.Mbid).HasColumnName("MBID");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mbname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MBName");
            });

            modelBuilder.Entity<ProcessorTable>(entity =>
            {
                entity.HasKey(e => e.Cpuid)
                    .HasName("PK__Processo__7D9B6772CE14DC62");

                entity.ToTable("Processor_Table");

                entity.Property(e => e.Cpuid).HasColumnName("CPUID");

                entity.Property(e => e.Cpufamily)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CPUFamily");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RamTable>(entity =>
            {
                entity.HasKey(e => e.Ramid)
                    .HasName("PK__RAM_Tabl__0CB20523DD2311BA");

                entity.ToTable("RAM_Table");

                entity.Property(e => e.Ramid).HasColumnName("RAMID");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User_Tab__1788CCAC87C7DCE1");

                entity.ToTable("User_Table");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}