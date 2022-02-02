using System;
using System.Collections.Generic;
using System.Text;
using Starbuck.Business.Models;
using System.Threading.Tasks;

namespace Starbuck.Business.Interfaces
{
    public interface IRepository<TEntity> :IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Remove(Guid id);

        Task<int> SaveChanges();
    }
}
