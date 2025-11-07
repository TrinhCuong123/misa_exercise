using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Fresher2025.Api.Model
{
    [Table("sale_order")]
    public class SaleOrder
    {
        [Key]
        [Column("sale_order_id")]
        public string? saleOrderId { get; set; }
        
        [Column("sale_order_no")]
        public string? saleOrderNo { get; set; }

        [Column("sale_order_date")]
        public DateTime saleOrderDate { get; set; }

        [Column("total_amount")]
        public double totalAmount { get; set; }

    }
}
