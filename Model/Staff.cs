using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// Thông tin người dùng
    /// </summary>
    [Table("Staff")]
    public class Staff : BaseEntity
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int StaffId { get; set; }

        /// <summary>
        /// Tên đăng nhập, duy nhất trong hệ thống
        /// </summary>
        [Required, MaxLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        /// <summary>
        /// Mật khẩu đã được mã hóa
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Họ tên đầy đủ của nhân viên
        /// </summary>
        [Required, MaxLength(100)]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Số điện thoại liên hệ
        /// </summary>
        [MaxLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        /// <summary>
        /// Email liên hệ
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Vai trò: Admin (quản trị), Staff (nhân viên y tế)
        /// </summary>
        [Required, MaxLength(20)]
        [Display(Name = "Vai trò")]
        public string Role { get; set; }

        /// <summary>
        /// Trạng thái hoạt động: 1-đang làm việc, 0-ngừng làm việc
        /// </summary>
        [Display(Name = "Trạng thái")]
        public bool IsActive { get; set; } = true;

        public ICollection<VaccinationRecord> VaccinationRecords { get; set; }

        public ICollection<Children> CreatedChildren { get; set; }
    }
}
