using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Core.Data;
using Scheduler.Domain.Core.Domain;
using Scheduler.Infra.Data.Context;

namespace Scheduler.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly AppointmentDataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppointmentDataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
