using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsAPI.Models
{
    [Table("Attributes")]
    public class Attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttributeId { get; set; }

        [Required]
        [StringLength(400)]
        public string AttributeName { get; set; }

        [Required]
        public string Value { get; set; }

        public string Unit { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
