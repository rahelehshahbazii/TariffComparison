using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TariffComparison.Contract;
using TariffComparison.Models;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     public class ProductsController : ControllerBase
     {
        
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

   
        // GET: api/Products
        [HttpGet]
        public IEnumerable <Product> GetProduct(double ConsumptionProductA, double ConsumptionProductB)
        {
           
            return _productRepository.GetAll(ConsumptionProductA, ConsumptionProductB);

        }
        private async Task<bool> ProductExists(int id)
        {
           return await _productRepository.IsExistedAsync(id);
        }

        // GET: api/Products/A
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id )
        {
           if (await ProductExists(id))
            {
                
                var product = await _productRepository.FindAsync(id);
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
           if( !ModelState.IsValid)
           {
                return BadRequest(ModelState);
           }
            
            await _productRepository.AddAsync(product);
            return CreatedAtAction("GetProduct", new { id = product.Productid }, product);
        }

        // PUT: api/Products/A
        [HttpPut("{id}")]

        public async Task<IActionResult> PutProduct([FromRoute]int id, [FromBody]Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productRepository.UpdateAsync(product);
            return Ok(product);
        }

        // DELETE: api/Products/A
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
           var product = await _productRepository.FindAsync(id);
           if (product == null)
            {
                return NotFound();
            }
            
            await _productRepository.RemoveAsync(id);
            return Ok(product);
        }

     }
}
