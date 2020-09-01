using Competitions.Application._Common;
using Competitions.Domain._Common;
using Competitions.Infrastructure._Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competitions.Infrastructure.Base
{
   public class RepositoryTemplate<T> : IRepositoryTemplate<T> where T : EntityBaseM
    {

        protected readonly AppDbContext _dbContext;

        private DbSet<T> SetInternal => _dbContext.Set<T>();
        public IQueryable<T> Set => SetInternal;


        public RepositoryTemplate(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


    }
}
