using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Starbuck.Api.ViewModels
{
    public class ExtraViewModel
    {
        [Key]
        public Guid Id { get; set; }

       
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} needs to be between {2} and {1}", MinimumLength = 2)]
        public float Price { get; set; }
    }
}
