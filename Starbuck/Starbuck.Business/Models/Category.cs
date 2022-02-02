using System;
using System.Collections.Generic;
using System.Text;

namespace Starbuck.Business.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
