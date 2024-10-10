using QuizApp.Data_Server;
using QuizApp.Models;
using QuizApp.Repository.IRepository;

namespace QuizApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IQuizRepository Quiz
        { get; private set; }
        public IQuestionRepository Question
        { get; private set; }
        public UnitOfWork(AppDbContext db) 
        {
            _db = db;
            Quiz = new QuizRepository(_db);
            Question = new QuestionRepository(_db);

        }
       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
