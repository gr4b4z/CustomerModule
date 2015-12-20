using System.Collections.Generic;

namespace CustomerTask.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        int Add(TEntity entity);
        void Delete(TEntity entity);
        void Commit();

    }
}
