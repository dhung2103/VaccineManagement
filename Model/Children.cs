using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// Lưu thông tin cá nhân của trẻ và phụ huynh
    /// </summary>
    [Table("Children")]
    public class Children : BaseEntity
    {
        [Key]
        [Display(Name = "Mã trẻ em")]
        public int ChildId { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(10)]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Nhóm máu
        /// </summary>
        [Display(Name = "Nhóm máu")]
        public string BloodType { get; set; } = string.Empty;

        /// <summary>
        /// Họ tên phụ huynh/người giám hộ
        /// </summary>
        [Required]
        [Display(Name = "Họ tên phụ huynh")]
        public string ParentName { get; set; } = string.Empty;

        /// <summary>
        /// Số điện thoại liên hệ của phụ huynh
        /// </summary>
        [Required]
        [Display(Name = "Số điện thoại phụ huynh")]
        public string ParentPhone { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ nơi ở
        /// </summary>
        [MaxLength(255)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Ghi chú về tình trạng sức khỏe, dị ứng, bệnh nền...
        /// </summary>
        [Display(Name = "Ghi chú sức khỏe")]
        public string HealthNotes { get; set; } = string.Empty;

        /// <summary>
        /// ID nhân viên tạo hồ sơ
        /// </summary>
        [Required]
        [Display(Name = "Người tạo")]
        public int CreatedBy { get; set; }

        public Staff CreatedByStaff { get; set; }

        public ICollection<VaccinationRecord> VaccinationRecords { get; set; }
    }
}
