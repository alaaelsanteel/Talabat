using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductSpecifications : BaseSpecifications<Product>
    {
        //creating obj will be used to get all products
        public ProductSpecifications()
            : base()
        {
            AddIncludes();
        }
        //creating obj will be used to get specific product with id
        public ProductSpecifications(int id)
            : base(P => P.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
