using Microsoft.EntityFrameworkCore;
using QuizAppRazor.Models;
using System.Configuration;

namespace QuizAppRazor.Data_server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        public DbSet<Quiz> Quizzes { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { quiz_id = 1, Topic = "SQL" }
                );
        }   
    }
}
