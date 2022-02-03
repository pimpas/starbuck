using System;
using System.ComponentModel.DataAnnotations;

namespace Starbuck.Api.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} needs to be between {2} and {1}", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
