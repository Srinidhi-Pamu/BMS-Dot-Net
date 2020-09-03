using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BMSwebapi.Models
{
    [Table("TransactionDetail")]
    public class TransactionDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id1 { get; set; }
        public Int64 AccountNumber { get; set; }
        [Required]
        public double Amount { get; set; }

        public DateTime TimeofTransaction { get; set; }
    }
}