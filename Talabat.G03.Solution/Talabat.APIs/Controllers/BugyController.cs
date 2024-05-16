using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Talabat.Core.Data;

namespace Talabat.APIs.Controllers
{
    public class BugyController:BaseApiController
    {
        private readonly StoreContext _dbContext;

        public BugyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _dbContext.Products.Find(100);
            if (product is null) return NotFound();
            return Ok(product);
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
           var product = _dbContext.Products.Find(100);
           var productToReturn = product.ToString(); //exception [NullReferenceException]
            return Ok(productToReturn);   
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() 
        {
            return BadRequest();
        }
        [HttpGet("badrequest/{id}")] // badrequest/five
        public ActionResult GetBadRequest(int id) //Validation Error
        {
            return Ok();
        }
    }
}
