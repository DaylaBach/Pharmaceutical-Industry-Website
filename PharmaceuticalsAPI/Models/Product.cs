using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsAPI.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductImage { get; set; }
        
        public string ProductSize { get; set; }

        public string Productivity { get; set; }

        public string MachineWeight { get; set; }

        public string ModelNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Attribute> Attributes { get; set; }
    }
}
