using Competitions.Domain._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competitions.Application._Common
{
    public interface IRepositoryTemplate<T> where T : EntityBaseM
    {
        
        IQueryable<T> Set { get; }

        
        T Add(T entity);
        

        
        void Update(T entity);
        

        
        void Delete(T entity);
        

        
        void SaveChanges();

    }
}
