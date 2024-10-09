using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Repository.IRepository;
using System.Linq.Expressions;

namespace QuizApp.Repository
{
    public class QuizRepository : Repository<Quiz> , IQuizRepository 
    {
        private AppDbContext _db;

        public QuizRepository(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        

        public void Update(Quiz obj)
        {
            _db.Quiz.Update(obj);
        }
    }
}
