using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenaricRepository<T> where T: BaseEntity //all entities inherts from it
    {
        Task<T?> GetAsync(int id);// nullable
        Task<IEnumerable<T>> GetAllAsync();
    }
}
