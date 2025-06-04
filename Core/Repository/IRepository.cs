using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get(); 
        Task<IEnumerable<TEntity>> GetById(int id);
        Task Add(TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);
        Task Save();
    }
}
