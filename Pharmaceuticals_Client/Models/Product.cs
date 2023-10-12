using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{

    public class Product
    {
        [Display(Name = "Id")]
        public string ProductId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Size")]
        public string ProductSize { get; set; }

        public string Productivity { get; set; }

        [Display(Name = "Weight")]
        public string MachineWeight { get; set; }

        [Display(Name = "Model number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Attribute> Attributes { get; set; }
    }
}
