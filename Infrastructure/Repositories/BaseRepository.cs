using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal InventarioBodegaContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(InventarioBodegaContext context) { 
            _context= context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
