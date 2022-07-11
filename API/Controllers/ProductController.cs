using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly StoreContext _context;

        public ProductController(ILogger<ProductController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
             var products = await _context.Products.ToListAsync();
             return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id){
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            return Ok(result);
        }

         
    }
}