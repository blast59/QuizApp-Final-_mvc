using Microsoft.EntityFrameworkCore;
using QuizAppRazor.Models;

namespace QuizAppRazor.Data_server
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public DbSet<Quiz> Quiz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
