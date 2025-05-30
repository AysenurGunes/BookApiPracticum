﻿using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookApi.DataAccess
{
    /// <summary>
    /// ismi BookRepository olsada BaseRepository olarak kullanılır.
    /// varsayılan servis işlemleri tanımlanır.
    /// Bu sayede tekrar tekrar servisi yazmaya gerek kalmıyor.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class BookRepository<TEntity, TContext> : IBook<TEntity>
        where TEntity : class, new()
        where TContext : BookDbContext, new()
    {
        private readonly BookDbContext _dbContext;
        public BookRepository()
        {
            _dbContext = new TContext();
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

        public int Delete(TEntity entity)
        {
            try
            {
                //var entit = _dbContext.Set<TEntity>().Where(expression).FirstOrDefault();
                _dbContext.Entry(entity).State = EntityState.Modified;
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

        public IList<TEntity> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>().ToList();

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
        public IList<TEntity> GetSpecial(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbContext.Set<TEntity>().Where(expression).ToList();
            }
            catch (Exception)
            {
                return new List<TEntity>();
            }
        }


    }
}
