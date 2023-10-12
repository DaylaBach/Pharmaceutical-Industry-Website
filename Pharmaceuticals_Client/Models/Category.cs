using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{
    public class Category
    {
        [Display(Name = "Id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        public int Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
