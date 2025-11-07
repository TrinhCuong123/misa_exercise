using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Fresher2025.Api.Model
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public string? customerId { get; set; }
        
        [Column("customer_code")]        
        public string? customerCode { get; set; }

        [Column("customer_name")]
        public string? customerName { get; set; }

        [Column("customer_addr")]
        public string? customerAddr { get; set; }
    }
}
