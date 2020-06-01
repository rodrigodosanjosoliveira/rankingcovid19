using Microsoft.EntityFrameworkCore;
using RankingCovid19.Data.Context;
using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RankingCovid19.Data.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : Entity
    {
        private readonly Covid19SummaryContext _context;

        public Repository(Covid19SummaryContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
