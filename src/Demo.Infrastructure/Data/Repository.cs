using Demo.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Data
{
    public class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>, IDisposable
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {

        protected readonly DbContext _dbContext;
        protected readonly DbSet<TAggregateRoot> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TAggregateRoot>();
        }

        public void Add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TAggregateRoot entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
