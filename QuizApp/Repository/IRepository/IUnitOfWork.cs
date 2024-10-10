namespace QuizApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IQuizRepository Quiz { get; }
        IQuestionRepository Question { get; }

        void Save();
    }
}
