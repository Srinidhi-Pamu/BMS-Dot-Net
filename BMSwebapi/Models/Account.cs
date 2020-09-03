using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BMSwebapi.Models
{
    [Table("Account")]
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public Int64 AccountNumber { get; set; }

        [Required(ErrorMessage = "Please enter firstname")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter lastname")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Mobile ")]
        public string Phone { get; set; }

        [StringLength(35)]
        public string Address { get; set; }
        [DisplayName("Amount")]
        public double Balance { get; set; }
    }
}