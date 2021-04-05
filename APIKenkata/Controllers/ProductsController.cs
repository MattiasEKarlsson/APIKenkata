using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIKenkata.Data;
using APIKenkata.Models;

namespace APIKenkata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ProductsController(SqlDbContext context)
        {
            _context = context;
        }

        //GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products/*Include(p => p.Brand).Include(p => p.Category).Include(p => p.Colour).Include(p => p.Size)*/.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    return await _context.Products/*.Include(p => p.BrandModel).Include(p => p.SizeModel)*/.ToListAsync();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    var products = new List<Product>();

        //    foreach (var product in await _context.Products.Include(p => p.Category).Include(p=>p.Brand).Include(p => p.Colour).Include(p => p.Size).ToListAsync())
        //    {
        //        var category = _context.Categorys.FirstOrDefault(category => category.Id == product.CategoryId);
        //        var size = _context.Sizes.FirstOrDefault(size => size.Id == product.SizeId);
        //        var colour = _context.Colours.FirstOrDefault(colour => colour.Id == product.ColourId);
        //        var brand = _context.Brands.FirstOrDefault(brand => brand.Id == product.BrandId);
        //        products.Add(new Product
        //        {
        //            Id = product.Id,
        //            ProductName = product.ProductName,
        //            ShortDescription = product.ShortDescription,
        //            LongDescription = product.LongDescription,
        //            StockCount = product.StockCount,
        //            Price = product.Price,
        //            OldPrize = product.OldPrize,
        //            Picture = product.Picture,
        //            CategoryId = product.CategoryId,
        //            ColourId = product.ColourId,
        //            BrandId = product.BrandId,
        //            SizeId = product.SizeId,
        //            Category = category,
        //            Colour = colour,
        //            Size = size,
        //            Brand = brand

        //        });

        //    }
        //    return products;
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var category = _context.Categorys.FirstOrDefault(category => category.Id == product.CategoryId);
            var brand = _context.Brands.FirstOrDefault(brand => brand.Id == product.BrandId);
            var size = _context.Sizes.FirstOrDefault(size => size.Id == product.SizeId);
            var colour = _context.Colours.FirstOrDefault(colour => colour.Id == product.ColourId);
            if (product == null)
            {
                return NotFound();
            }
            product.Brand = brand;
            product.Category = category;
            product.Size = size;
            product.Colour = colour;
            return product;
        }


        //GET: api/Products/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}



       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
