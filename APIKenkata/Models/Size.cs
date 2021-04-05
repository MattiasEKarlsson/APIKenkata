using System;
using System.Collections.Generic;

#nullable disable

namespace APIKenkata.Models
{
    public partial class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
