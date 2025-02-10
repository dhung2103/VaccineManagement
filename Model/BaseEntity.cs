using PropertyChanged;
using System;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagement.Model
{
    [AddINotifyPropertyChangedInterface]
    public class BaseEntity
    {
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Ngày sửa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
