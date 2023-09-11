using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
	public interface IEntityRepository<T> where T:class, IEntity,new()
	{
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        //List<T> GetById(int entityId);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

