namespace QuizApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IQuizRepository Quiz { get; }
        void Save();
    }
}
