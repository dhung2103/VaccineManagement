using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// Bảng trung gian giữa gói vaccine và vaccine
    /// many to many
    /// </summary>
    [Table("VaccinationPackages")]
    public class VaccinationPackage : BaseEntity
    {
        [Key]
        [Display(Name = "Mã gói tiêm")]
        public int PackageId { get; set; }

        /// <summary>
        /// Tên gói tiêm
        /// </summary>
        [Required, MaxLength(200)]
        [Display(Name = "Tên gói tiêm")]
        public string Name { get; set; }

        /// <summary>
        /// Mô tả chi tiết về gói tiêm
        /// </summary>
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        /// <summary>
        /// Giá gói tiêm
        /// </summary>
        [Required]
        [Display(Name = "Giá gói")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Trạng thái: 1-đang cung cấp, 0-ngừng cung cấp
        /// </summary>
        [Display(Name = "Trạng thái")]
        public bool? IsActive { get; set; }

        public ICollection<PackageVaccine> PackageVaccines { get; set; } = new List<PackageVaccine>();
        public ICollection<VaccinationRecord> VaccinationRecords { get; set; } = new List<VaccinationRecord>();
    }
}
