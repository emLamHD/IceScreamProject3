using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("order_details")]
    public partial class OrderDetail
    {
        [Key]
        [Column("OrderDetailId")]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "OrderId không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "OrderId phải lớn hơn 0")]
        public int? OrderId { get; set; }

        [Required(ErrorMessage = "ProductId không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId phải lớn hơn 0")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Quantity không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity phải lớn hơn hoặc bằng 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice phải lớn hơn 0")]
        [DataType(DataType.Currency, ErrorMessage = "Định dạng không hợp lệ")]
        public decimal UnitPrice { get; set; }
    }
}
