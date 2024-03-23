using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
                                                  // query over a DbSet, specification obj for modifing inputQuery
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query= inputQuery; //_dbContext.Set<Product>()

            if(spec.Criteria is not null) // p => p.Id == 1
            {
                query = query.Where(spec.Criteria);
            }
            //query = _dbContext.Set<Product>().Where(p => p.Id ==1)
            //Includes
            //1. p => p.Brand
            //2. p =>p.Category

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            //_dbContext.Set<Product>().Where(p => p.Id == 1).Include( p => p.Brand)
            //_dbContext.Set<Product>().Where(p => p.Id == 1).Include( p => p.Brand).Include(p =>p.Category)

            return query; 
        }
    }
}
