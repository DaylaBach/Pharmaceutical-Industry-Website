using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Feedback Id")]
        public int FeedbackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [StringLength(150)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(100)]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(100)]
        [Display(Name = "State")]
        public string State { get; set; }

        [StringLength(300)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(150)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [StringLength(1000)]
        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created_date { get; set; }


    }
}
