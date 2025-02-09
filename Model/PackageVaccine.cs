using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineManagement.Model
{
    /// <summary>
    /// các gói vaccine
    /// </summary>
    [Table("PackageVaccines")]
    public class PackageVaccine
    {
        [Display(Name = "Mã gói tiêm")]
        public int PackageId { get; set; }

        [Display(Name = "Mã vaccine")]
        public int VaccineId { get; set; }

        /// <summary>
        /// Thứ tự tiêm trong gói
        /// </summary>
        [Required]
        [Display(Name = "Thứ tự tiêm")]
        public int DoseOrder { get; set; }

        /// <summary>
        /// Giá vaccine trong gói (có thể khác giá lẻ)
        /// </summary>
        [Display(Name = "Giá vaccine")]
        public decimal? Price { get; set; }

        public VaccinationPackage Package { get; set; }
        public Vaccine Vaccine { get; set; }
    }
}
