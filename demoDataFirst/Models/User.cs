using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("users")]
    public partial class User
    {
        [Key]
        [Column("UserID")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
        [Column("FullName")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        [StringLength(255, ErrorMessage = "Email không được vượt quá 255 ký tự.")]
        [Column("Email")]
        public string Email { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Mật khẩu không được vượt quá 255 ký tự.")]
        [Column("PasswordHash")]
        public string? PasswordHash { get; set; }

        [StringLength(50, ErrorMessage = "Nhà cung cấp đăng nhập không được vượt quá 50 ký tự.")]
        [Column("LoginProvider")]
        public string? LoginProvider { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Số dư phải lớn hơn hoặc bằng 0.")]
        [Column("Balance")]
        public decimal? Balance { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Required(ErrorMessage = "Vai trò là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Vai trò không được vượt quá 50 ký tự.")]
        [Column("Role")]
        public string Role { get; set; } = "user";

        [StringLength(255, ErrorMessage = "Liên kết ảnh đại diện không được vượt quá 255 ký tự.")]
        [Column("Avatar")]
        public string? Avatar { get; set; }
    }
}
