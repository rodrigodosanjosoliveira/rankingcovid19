using RankingCovid19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RankingCovid19.Domain.Contracts.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(Guid id);
    }
}
