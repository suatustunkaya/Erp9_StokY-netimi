using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sy.Core.Entities;

namespace Sy.Core.Abstracts
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        TEntity GetById(TKey Id);
        TKey Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Save();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> Predicate = null);
    }
}
