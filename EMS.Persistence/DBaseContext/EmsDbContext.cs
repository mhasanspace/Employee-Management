using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EMS.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace EMS.Persistence.DBaseContext
{
    public partial class EmsDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public EmsDbContext()
        {
        }

        public EmsDbContext(DbContextOptions<EmsDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<BloodGroup> BloodGroups { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Division> Divisions { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuAccess> MenuAccesses { get; set; } = null!;
        public virtual DbSet<OrgDivision> OrgDivisions { get; set; } = null!;
        public virtual DbSet<OtherMenuAccess> OtherMenuAccesses { get; set; } = null!;
        public virtual DbSet<Thana> Thanas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    string connectionString = _configuration.GetConnectionString("DefaultConnection");
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    optionsBuilder.UseSqlServer("Server=.;Database=EAMS_DB;Trusted_Connection=True;TrustServerCertificate=True");
                }

            }
            catch (Exception)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=EAMS_DB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.Property(e => e.TotalWorkingHour).HasDefaultValueSql("('0.00')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Attendanc__UserI__74AE54BC");
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup");

                entity.Property(e => e.BloodGroupName).HasMaxLength(75);

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode).HasMaxLength(20);

                entity.Property(e => e.DepartmentName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrgDivision)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.OrgDivisionId)
                    .HasConstraintName("FK__Departmen__OrgDi__3C69FB99");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DesignationCode).HasMaxLength(20);

                entity.Property(e => e.DesignationName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Designations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Designati__Depar__4222D4EF");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistrictName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__District__Divisi__5165187F");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DivisionName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ManuName).HasMaxLength(250);

                entity.Property(e => e.MenuParentId).HasDefaultValueSql("('0')");

                entity.Property(e => e.MenuSerialNo).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<MenuAccess>(entity =>
            {
                entity.ToTable("MenuAccess");

                entity.Property(e => e.CanCreate)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanDelete)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanEdit)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanManage)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanViewDetails)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanViewList)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuAccesses)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__MenuAcces__MenuI__00200768");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.MenuAccesses)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK__MenuAcces__UserG__7F2BE32F");
            });

            modelBuilder.Entity<OrgDivision>(entity =>
            {
                entity.ToTable("OrgDivision");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<OtherMenuAccess>(entity =>
            {
                entity.ToTable("OtherMenuAccess");

                entity.Property(e => e.CanApprove)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanPublish)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CanReject)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.MenuAccess)
                    .WithMany(p => p.OtherMenuAccesses)
                    .HasForeignKey(d => d.MenuAccessId)
                    .HasConstraintName("FK__OtherMenu__MenuA__0B91BA14");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.ToTable("Thana");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ThanaName).HasMaxLength(75);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Thana__DistrictI__5812160E");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__Thana__DivisionI__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserEmail, "UQ__User__08638DF8A177C752")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__User__C9F28456F5582D99")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNo, "UQ__User__F3EE33E20A5216EE")
                    .IsUnique();

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(75);

                entity.Property(e => e.Password).HasMaxLength(15);

                entity.Property(e => e.PhoneNo).HasMaxLength(15);

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(75);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__User__Department__6D0D32F4");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__User__Designatio__6E01572D");

                entity.HasOne(d => d.OrgDivision)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrgDivisionId)
                    .HasConstraintName("FK__User__OrgDivisio__6C190EBB");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK__User__UserGroupI__6B24EA82");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__User__UserTypeId__6A30C649");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("UserGroup");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupName).HasMaxLength(75);

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.CreateBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifyBy).HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModifyDate).HasColumnType("datetime");

                entity.Property(e => e.TypeName).HasMaxLength(75);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
