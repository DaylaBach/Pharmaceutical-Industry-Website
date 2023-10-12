using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{
    public class Attribute
    {
        [Display(Name = "Id")]
        public int AttributeId { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Name")]
        public string AttributeName { get; set; }

        [Required]
        public string Value { get; set; }

        public string Unit { get; set; }

        [Display(Name = "Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
