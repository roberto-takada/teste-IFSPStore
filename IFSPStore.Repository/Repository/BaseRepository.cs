using IFSPStore.Domain.Base;
using IFSPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlcontext)
        {
            _mySqlContext = mySqlcontext;
        }
        public void AtachObject(object obj)
        {
            _mySqlContext.Attach(obj);
        }

        public void ClearChangeTracker()
        {
            _mySqlContext.ChangeTracker.Clear();
        }

        public void Delete(object id)
        {
            _mySqlContext.Set<TEntity>().Remove(Select(id));
            _mySqlContext.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            _mySqlContext.Set<TEntity>().Add(entity);
            _mySqlContext.SaveChanges();
        }

        public IList<TEntity> Select(IList<string>? includes = null)
        {
            var dbContext = _mySqlContext.Set<TEntity>().AsQueryable();
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList();
        }

        public TEntity Select(object id, IList<string>? includes = null)
        {
            var dbContext = _mySqlContext.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList().Find(x => x.Id == (int)id);
        }

        public void Update(TEntity entity)
        {
            _mySqlContext.Entry(entity).State = EntityState.Modified;
            _mySqlContext.SaveChanges();
        }
    }
}
