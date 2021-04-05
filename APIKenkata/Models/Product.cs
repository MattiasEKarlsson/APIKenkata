using System;
using System.Collections.Generic;

#nullable disable

namespace APIKenkata.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrize { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Size Size { get; set; }

       
    }
}
