using System;
using System.Collections.Generic;

#nullable disable

namespace APIKenkata.Models
{
    public partial class Colour
    {
        public Colour()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ColourName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
