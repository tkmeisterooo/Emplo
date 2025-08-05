using EmploTask2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmploTask2.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationPackage> VacationPackages { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();

                entity.HasOne(o => o.Team)
                    .WithMany(o => o.Employees)
                    .HasForeignKey(o => o.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.VacationPackage)
                    .WithMany(o => o.Employees)
                    .HasForeignKey(o => o.VacationPackageId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(o => o.Vacations)
                    .WithOne(o => o.Employee)
                    .HasForeignKey(o => o.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Ignore(o => o.UsedVacationDays);

            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<VacationPackage>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Vacation>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();
            });


            base.OnModelCreating(builder);
        }

    }
}
