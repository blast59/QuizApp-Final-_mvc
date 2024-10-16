﻿using System.Linq.Expressions;

namespace QuizApp.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Quiz , Question 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T , bool>> filter);
        void Add(T entity);
       // void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
