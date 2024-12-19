using System;
using System.ComponentModel.DataAnnotations; // Thêm namespace này để dùng Data Annotations
using System.ComponentModel.DataAnnotations.Schema; // Thêm namespace này để ánh xạ với cơ sở dữ liệu

namespace demoDataFirst.Models
{
    [Table("users")] // Ánh xạ với bảng "users" trong cơ sở dữ liệu
    public partial class User
    {
        [Key]
        [Column("UserID")] // Ánh xạ với cột "UserID" trong cơ sở dữ liệu
        public int UserId { get; set; } // Khóa chính

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
        [Column("FullName")] // Ánh xạ với cột "FullName"
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        [StringLength(255, ErrorMessage = "Email không được vượt quá 255 ký tự.")]
        [Column("Email")] // Ánh xạ với cột "Email"
        public string Email { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Mật khẩu không được vượt quá 255 ký tự.")]
        [Column("PasswordHash")] // Ánh xạ với cột "PasswordHash"
        public string? PasswordHash { get; set; }

        [StringLength(50, ErrorMessage = "Nhà cung cấp đăng nhập không được vượt quá 50 ký tự.")]
        [Column("LoginProvider")] // Ánh xạ với cột "LoginProvider"
        public string? LoginProvider { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Số dư phải lớn hơn hoặc bằng 0.")]
        [Column("Balance")] // Ánh xạ với cột "Balance"
        public decimal? Balance { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Tự động cập nhật từ SQL Server
        [Column("CreatedAt")] // Ánh xạ với cột "CreatedAt"
        public DateTime? CreatedAt { get; set; }
    }
}
