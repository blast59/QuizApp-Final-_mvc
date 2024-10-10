using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Repository.IRepository;
using System.Linq.Expressions;

namespace QuizApp.Repository
{
    public class QuestionRepository : Repository<Question> , IQuestionRepository
    {
        private AppDbContext _db;

        public QuestionRepository(AppDbContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Question obj)
        {
            _db.Question.Update(obj);
        }
    }
}
