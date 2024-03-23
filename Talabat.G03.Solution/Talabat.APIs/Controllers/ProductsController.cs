 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.Product_Specs;

namespace Talabat.APIs.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenaricRepository<Product> _productsRepo;

        public ProductsController(IGenaricRepository<Product>productsRepo)
        {
            _productsRepo = productsRepo;
        }
        [HttpGet]// /api/Products
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var spec = new ProductSpecifications();
            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            return Ok(products);
        }
        [HttpGet("{id}")]// /api/Products/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await _productsRepo.GetWithSpecAsync(spec);

            if(product is null) 
                return NotFound(); //404

            return Ok(product); //200
        }
    }
}
