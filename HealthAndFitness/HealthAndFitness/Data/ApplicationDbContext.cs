namespace HealthAndFitness.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using HealthAndFitness.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Video> Videos{ get; set; }
    }
}