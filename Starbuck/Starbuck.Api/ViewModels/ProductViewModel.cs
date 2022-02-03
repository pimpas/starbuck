using Starbuck.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Starbuck.Api.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage ="Price has to be bigger than {0}")]
        public float? Price { get; set; }

        public int Stock { get; set; }
    }
}
