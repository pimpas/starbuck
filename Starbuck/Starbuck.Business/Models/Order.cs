using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Starbuck.Business.Models
{
    public class Order
    {
        public Product Product { get; set; }

        public IEnumerable<Extra> Extras { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price has to be bigger than {0}")]
        public float MoneySent { get; set; }
    }
}
