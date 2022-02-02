using System;
using System.Collections.Generic;
using System.Text;

namespace Starbuck.Business.Models
{
    public class Product : Entity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public Decimal Price { get; set; }

        public int Stock { get; set; }

        public Category Category { get; set; }

        
    }
}
