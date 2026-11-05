using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Contracts
{
    public interface IRepository<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        void Add(TAggregateRoot entity);
        Task AddAsync(TAggregateRoot entity, CancellationToken cancellationToken);
        //void Edit(TAggregateRoot entity);
        //Task EditAsync(TAggregateRoot entity, CancellationToken cancellationToken);
        //void Remove(TAggregateRoot entityToDelete);

        //IList<TAggregateRoot> GetAll();
        //Task<IList<TAggregateRoot>> GetAllAsync(CancellationToken cancellationToken);

        //TAggregateRoot GetById(TKey id);
        //Task<TAggregateRoot?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

    }
}
