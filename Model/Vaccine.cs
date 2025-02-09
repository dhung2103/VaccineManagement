using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// Thông tin các vaccine
    /// </summary>
    [Table("Vaccines")]
    public class Vaccine : BaseEntity
    {
        [Key]
        [Display(Name = "Mã vaccine")]
        public int VaccineId { get; set; }

        /// <summary>
        /// Tên vaccine
        /// </summary>
        [Required, MaxLength(100)]
        [Display(Name = "Tên vaccine")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Nhà sản xuất
        /// </summary>
        [Required, MaxLength(200)]
        [Display(Name = "Nhà sản xuất")]
        public string Manufacturer { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả chi tiết về vaccine
        /// </summary>
        [Display(Name = "Mô tả")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        ///  Độ tuổi tối thiểu (tính bằng tháng)
        /// </summary>
        [Display(Name = "Tuổi tối thiểu")]
        public int? MinAgeMonths { get; set; }

        /// <summary>
        /// Độ tuổi tối đa (tính bằng tháng)
        /// </summary>
        [Display(Name = "Tuổi tối đa")]
        public int? MaxAgeMonths { get; set; }

        /// <summary>
        /// Thông tin về liều lượng
        /// </summary>
        [Display(Name = "Liều lượng")]
        public string DosageInfo { get; set; } = string.Empty;

        /// <summary>
        /// Đơn giá tiêm lẻ
        /// </summary>
        [Display(Name = "Giá tiêm")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Trạng thái: 1-đang sử dụng, 0-ngừng sử dụng
        /// </summary>
        [Display(Name = "Trạng thái")]
        public bool? IsActive { get; set; }

        public ICollection<PackageVaccine> PackageVaccines { get; set; } = new List<PackageVaccine>();
        public ICollection<VaccinationRecord> VaccinationRecords { get; set; } = new List<VaccinationRecord>();
    }
}
