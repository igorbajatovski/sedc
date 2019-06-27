using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMatchesDemo.Data
{
    public interface IRepository<T> 
    {
        ICollection<T> GetAll();
        void Save(T entity);
    }
}
