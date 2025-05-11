using Excavator.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Database.Data
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
            where TKey : IEquatable<TKey>;

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
