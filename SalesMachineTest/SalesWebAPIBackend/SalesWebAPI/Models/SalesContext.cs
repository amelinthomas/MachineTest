using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesWebAPI.Models
{
    public partial class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<VisitTable> VisitTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=AMELINTHOMAS\\SQLEXPRESS; Initial Catalog=Sales; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__128545295A336B9A");

                entity.Property(e => e.EmpId).HasColumnName("emp_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_Id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__EmployeeR__IsAct__29572725");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7F2E2A0F0806825");

                entity.Property(e => e.LId).HasColumnName("l_Id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VisitTable>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__VisitTab__DB49A428BCB97176");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_No")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("Cust_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("Emp_id");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("Interest_Product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("Is_Disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("Visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("Visit_Subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.VisitTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__VisitTabl__Emp_i__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
