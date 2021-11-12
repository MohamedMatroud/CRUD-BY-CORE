using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CrudMind
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }

        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "last  Name")]
        public string CustomerLastName { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Gender")]
        public string CustomerGender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime? CustomerDob { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
