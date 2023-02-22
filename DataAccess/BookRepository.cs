using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookApi.DataAccess
{
    public class BookRepository<TEntity> : IBook<TEntity>
        where TEntity : class, new()
        //where TContext:BookDbContext,new()
    {
        private readonly BookDbContext _dbContext;
        public BookRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Added;
                _dbContext.SaveChanges();
                return StatusCodes.Status200OK;
            }
            catch (Exception)
            {

                return StatusCodes.Status400BadRequest;
            }
        }

        public int Delete(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entit = _dbContext.Set<TEntity>().Where(expression).FirstOrDefault();
                _dbContext.Entry(entit).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return StatusCodes.Status200OK;
            }
            catch (Exception)
            {
                return StatusCodes.Status400BadRequest;
            }
        }

        public int Edit(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return StatusCodes.Status200OK;
            }
            catch (Exception)
            {
                return StatusCodes.Status400BadRequest;
            }
        }

        public IList<TEntity> GetAllBook()
        {
            try
            {
             return  _dbContext.Set<TEntity>().ToList();

            }
            catch (Exception)
            {
                return new List<TEntity>();
            }
        }

        public TEntity GetByID(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbContext.Set<TEntity>().Where(expression).FirstOrDefault();
            }
            catch (Exception)
            {
                return new TEntity();
            }
        }
       
    }
}
