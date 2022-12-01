using BLL2.Interfaces;
using DAL2.Context;
using DAL2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly MVCAppDbContext _dbContext;
        public GenericRepository(MVCAppDbContext dbContext)
        {
            _dbContext = dbContext;

        }    

        public async Task<int> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
        => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
        => await _dbContext.Set<T>().ToListAsync();

       
        public async Task<int> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
