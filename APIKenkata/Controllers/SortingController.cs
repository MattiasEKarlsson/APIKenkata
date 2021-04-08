using APIKenkata.Data;
using APIKenkata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIKenkata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {

        private readonly SqlDbContext _context;

        public SortingController(SqlDbContext context)
        {
            _context = context;
        }


        [HttpGet("/Size/{size}")]
        public async Task<ActionResult> GetSizes(string size)
        {
            var quarable = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(size))
                quarable = quarable.Where(q => q.Size.SizeName == size);

            return new OkObjectResult(await quarable.ToListAsync());
        }

        [HttpGet("/Colour/{colour}")]
        public async Task<ActionResult> GetColour(string colour)
        {
            var quarable = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(colour))
                quarable = quarable.Where(q => q.Colour.ColourName == colour);

            return new OkObjectResult(await quarable.ToListAsync());
        }

        [HttpGet("/Brand/{brand}")]
        public async Task<ActionResult> GetBrand(string brand)
        {
            var quarable = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(brand))
                quarable = quarable.Where(q => q.Brand.BrandName == brand);

            return new OkObjectResult(await quarable.ToListAsync());
        }

        [HttpGet("/Category/{category}")]
        public async Task<ActionResult> GetCategory(string category)
        {
            var quarable = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                quarable = quarable.Where(q => q.Category.CategoryName == category);

            return new OkObjectResult(await quarable.ToListAsync());
        }

        [HttpGet("/Maxprice/{maxprice}")]
        public async Task<ActionResult> GetMaxPrice(int maxprice)
        {
            var quarable = _context.Products.AsQueryable();
                quarable = quarable.Where(q => q.Price <= maxprice);
                return new OkObjectResult(await quarable.ToListAsync());

        }

        

        [HttpGet("/Newest")]
        public async Task<ActionResult<IEnumerable<Product>>> GetNewestProducts()
        {
            var newList =  _context.Products.OrderByDescending(x => x.Id).ToList();
            return newList; 
        }

        [HttpGet("/Cheapest")]
        public async Task<ActionResult<IEnumerable<Product>>> GetCheapestProducts()
        {
            var newList = _context.Products.OrderBy(x => x.Price).ToList();
            return newList;
        }

        [HttpGet("/Expensive")]
        public async Task<ActionResult<IEnumerable<Product>>> GetExpensiveProducts()
        {
            var newList = _context.Products.OrderByDescending(x => x.Price).ToList();
            return newList;
        }


    }
}
