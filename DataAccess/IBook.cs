using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookApi.DataAccess
{
    public interface IBook<T>
    {
        IList<T> GetAll();
        T GetByID(Expression<Func<T, bool>> expression);
        IList<T> GetSpecial(Expression<Func<T, bool>> expression);
        
        int Add(T entity);
        int Edit(T entity);
        int Delete(T entity);
       
    }
}
