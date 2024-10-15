using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using static System.Formats.Asn1.AsnWriter;

namespace QuizApp.Data_Server
{
    public class AppDbContext : IdentityDbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Submission> Submission { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Quiz>().HasData(
                    new Quiz { quiz_id = 1, Topic = "SQL" },
                    new Quiz { quiz_id = 2, Topic = "C#" },
                    new Quiz { quiz_id = 3, Topic = ".Net" }
         );
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuizId = 1,
                    QuestionText = "In which University was PostGres Developed",
                    OptionA = "MIT",
                    OptionB = "Harvard",
                    OptionC = "University of California, Berkeley",
                    OptionD = "Tsinghua University, Beijing",
                    CorrectOption = "University of California, Berkeley",
                    TimeLimitInSeconds = 30,
                    Difficulty = "easy",
                    CreatedBy = 1,
                });
               // Call base.OnModelCreating to configure Identity tables
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Submission and AspNetUsers
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.User)  // A Submission has one User
                .WithMany()           // A User can have many Submissions
                .HasForeignKey(s => s.UserId)  // UserId is the foreign key
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete behavior
           
            //modelBuilder.Entity<Submission>().HasData(
            //        new Submission { Submission_Id = 1, UserId = 1, Quiz_Id = 1, Score = "10",SubmittedAt=DateTime.UtcNow }
            //        );
                    
        }
    }
}



