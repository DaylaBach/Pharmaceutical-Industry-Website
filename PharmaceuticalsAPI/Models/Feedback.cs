using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsAPI.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }
        
        [StringLength(100)]
        public string State { get; set; }

        [StringLength(300)]
        public string PostalCode { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [StringLength(1000)]
        public string Comments { get; set; }

        public DateTime Created_date { get; set; }
    }
}
