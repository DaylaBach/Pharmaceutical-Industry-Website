using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Models
{
    public class Manager
    {
        [Display(Name = "Id")]
        public Guid AdminId { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20), MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20), MinLength(6), MaxLength(20)]
        public string Password { get; set; }

        public int? Role { get; set; }

        [StringLength(450)]
        public string Image { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created_date { get; set; }
    }
}
