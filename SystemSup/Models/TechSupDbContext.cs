using Microsoft.EntityFrameworkCore;

namespace SystemSup.Models
{
    public partial class TechSupDbContext : DbContext
    {
        public TechSupDbContext()
        {
        }

        public TechSupDbContext(DbContextOptions<TechSupDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activ> Activs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Lifecycle> Lifecycles { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TechSupDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activ>(entity =>
            {
                entity.Property(e => e.CabNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Activs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Activs_ToDepartments");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lifecycle>(entity =>
            {
                entity.Property(e => e.Checking).HasColumnType("datetime");

                entity.Property(e => e.Closed).HasColumnType("datetime");

                entity.Property(e => e.Distributed).HasColumnType("datetime");

                entity.Property(e => e.Opened).HasColumnType("datetime");

                entity.Property(e => e.Proccesing).HasColumnType("datetime");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.File).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Activ)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ActivId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Requests_ToActivs");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Requests_ToCategories");

                entity.HasOne(d => d.Lifecycle)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.LifecycleId)
                    .HasConstraintName("FK_Requests_ToLifecycles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Requests_ToUsers");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Users_ToDepartments");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_ToRoles");
            });
        }
    }
}
