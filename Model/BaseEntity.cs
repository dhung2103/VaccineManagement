using PropertyChanged;
using System;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagement.Model
{
    [AddINotifyPropertyChangedInterface]
    public class BaseEntity
    {
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày sửa")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
