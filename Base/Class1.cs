using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Model;

namespace Base
{
  public interface ICustomerRepository:IRepository<Customer>
    {
    

    }

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
