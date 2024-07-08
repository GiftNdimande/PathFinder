using Microsoft.EntityFrameworkCore;

namespace PathFinderAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Learnership> Learnership { get; set; }
        public DbSet<Bursarie> Bursarie  { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey("UserId");

            modelBuilder.Entity<DataFiles>().ToTable("Datafiles");
            modelBuilder.Entity<DataFiles>().HasKey("DataFileId");

            modelBuilder.Entity<Communication>().ToTable("Communication");
            modelBuilder.Entity<Communication>().HasKey("CommunicationId");

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey("CourseId");

            modelBuilder.Entity<Learnership>().ToTable("Learnership");
            modelBuilder.Entity<Learnership>().HasKey("LearnershipId");

            modelBuilder.Entity<Bursarie>().ToTable("Bursarie");
            modelBuilder.Entity<Bursarie>().HasKey("BursarieId");

            modelBuilder.Entity<Result>().ToTable("Result");
            modelBuilder.Entity<Result>().HasKey("ResultId");

            }
    }
}
