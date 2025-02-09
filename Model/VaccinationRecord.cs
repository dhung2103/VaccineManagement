using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// Bảng tiêm chủng: Ghi nhận thông tin các mũi tiêm của bệnh nhân
    /// </summary>
    [Table("VaccinationRecords")]
    public class VaccinationRecord
    {
        [Key]
        [Display(Name = "Mã tiêm chủng")]
        public int RecordId { get; set; }

        /// <summary>
        /// ID trẻ được tiêm
        /// </summary>
        [Required]
        [Display(Name = "Mã trẻ")]
        public int? ChildId { get; set; }

        [Display(Name = "Mã trẻ")]
        public Children Child { get; set; }

        /// <summary>
        /// ID vaccine được tiêm
        /// </summary>
        [Display(Name = "Mã vaccine")]
        public int? VaccineId { get; set; }

        [Display(Name = "Mã vaccine")]
        public Vaccine Vaccine { get; set; } = null;

        /// <summary>
        /// ID gói tiêm (nếu có)
        /// </summary>
        /// 
        [Display(Name = "Gói tiêm")]
        public int? PackageId { get; set; }

        [Display(Name = "Gói tiêm")]
        public VaccinationPackage Package { get; set; } = null;

        /// <summary>
        /// ID nhân viên thực hiện tiêm
        /// </summary>
        [Display(Name = "Nhân viên tiêm")]
        public int? AdministeredBy { get; set; }

        [Display(Name = "Nhân viên tiêm")]
        public Staff AdministeredByStaff { get; set; } = null;

        /// <summary>
        /// Thời điểm tiêm
        /// </summary>
        [Display(Name = "Thời gian tiêm")]
        public DateTime? AdministeredDate { get; set; }

        /// <summary>
        /// Số lô vaccine
        /// </summary>
        [Display(Name = "Số lô vaccine")]
        public string LotNumber { get; set; } = string.Empty;

        /// <summary>
        /// Hạn sử dụng vaccine
        /// </summary>
        [Display(Name = "Hạn sử dụng")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Vị trí tiêm
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "Vị trí tiêm")]
        public string InjectionSite { get; set; } = string.Empty;

        /// <summary>
        /// Ghi chú thêm
        /// </summary>
        [MaxLength(255)]
        [Display(Name = "Ghi chú")]
        public string Notes { get; set; } = string.Empty;

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
