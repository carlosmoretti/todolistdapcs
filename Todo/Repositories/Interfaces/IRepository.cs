using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int id);
    }
}
