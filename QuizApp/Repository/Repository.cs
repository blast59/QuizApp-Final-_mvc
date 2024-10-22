using QuizApp.Repository.IRepository;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using QuizApp.Data_Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuizApp.Repository
{
    public class Repository<T> : IRepository<T>where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet ;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();  
            //_db.Quiz == dbSet
            //_db.Quiz.Add(entity) == dbSet(entity)

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            
        }
        public T Get(Expression<Func<T, bool>> filter)              //to retrieve one instance having some condition
        { 
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);   
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);  
        }
    }
}
