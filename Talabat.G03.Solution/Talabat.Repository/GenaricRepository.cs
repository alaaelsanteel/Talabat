using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Data;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StoreContext  _dbContext;
        public GenericRepository(StoreContext dbContext)//Ask CLR for creating object from DbContext Implicitly 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id); //FindAsync can reurn obj or null
        }
    }
}
