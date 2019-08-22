using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
