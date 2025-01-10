using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }  // Primary Key

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId { get; set; }  // Sẽ lưu trữ ProductId liên kết với bảng Product

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string ImageUrl { get; set; }  // Đường dẫn đến ảnh

        public Product Product { get; set; }
    }


}
