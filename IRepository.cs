using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;

namespace ContosoUniversity 
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);        
        void Update(T entity);
        void Delete(T entity);
    }
}
