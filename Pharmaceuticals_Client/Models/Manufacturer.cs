using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{
    
    public class Manufacturer
    {
        [Display(Name = "Id")]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(400)]
        [Display(Name = "Name")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Address")]
        public string Adress { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
