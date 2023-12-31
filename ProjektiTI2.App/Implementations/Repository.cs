﻿using Microsoft.EntityFrameworkCore;
using ProjektiTI2.App.Interfaces;
using ProjektiTI2.Data.Context;
using System.Linq.Expressions;

namespace ProjektiTI2.App.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProjektiTI2_Viti3Context _context;

        public Repository(ProjektiTI2_Viti3Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().AddRange(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRange(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().UpdateRange(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicte, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>().Where(predicte);
                return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public T FindOne(Expression<Func<T, bool>> predicte)
        {
            try
            {
                return _context.Set<T>().FirstOrDefault(predicte);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
