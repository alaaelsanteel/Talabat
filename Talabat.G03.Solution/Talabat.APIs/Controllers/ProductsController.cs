 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIs.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenaricRepository<Product> _productRepo;

        public ProductsController(IGenaricRepository<Product>productRepo)
        {
            _productRepo = productRepo;
        }
    }
}
