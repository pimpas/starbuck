using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Starbuck.Business.Interfaces;
using Starbuck.Business.Models;
using Starbuck.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Starbuck.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly MyDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
  
        protected Repository(MyDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
