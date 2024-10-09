using QuizApp.Models;
namespace QuizApp.Repository.IRepository
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        void Update(Quiz obj);
            

    }
}
