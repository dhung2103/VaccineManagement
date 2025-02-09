using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VaccinationManagement.Data;
using VaccineManagement.Command;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;

namespace VaccineManagement.UserViewControl.VaccinationRecordView
{
    public class VaccinationRecordViewModel : BaseViewModel
    {
        private VaccinationRecord _vaccinationRecord;
        public VaccinationRecord VaccinationRecord
        {
            get { return _vaccinationRecord; }
            set
            {
                _vaccinationRecord = value;
                OnPropertyChanged(nameof(VaccinationRecord));
            }
        }

        private List<Vaccine> _vaccines;
        public List<Vaccine> Vaccines
        {
            get { return _vaccines; }
            set
            {
                _vaccines = value;
                OnPropertyChanged(nameof(Vaccines));
            }
        }

        private List<VaccinationPackage> _packages;
        public List<VaccinationPackage> Packages
        {
            get { return _packages; }
            set
            {
                _packages = value;
                OnPropertyChanged(nameof(Packages));
            }
        }

        private List<Staff> _administeredByUsers;
        public List<Staff> AdministeredByUsers
        {
            get { return _administeredByUsers; }
            set
            {
                _administeredByUsers = value;
                OnPropertyChanged(nameof(AdministeredByUsers));
            }
        }

        public ICommand SaveCommand { get; set; }

        public VaccinationRecordViewModel()
        {
            VaccinationRecord = new VaccinationRecord
            {
                AdministeredDate = DateTime.Now,
                CreatedAt = DateTime.Now
            };

            // Load data from context
            LoadVaccines();
            LoadPackages();
            LoadAdministeredByUsers();

            SaveCommand = new RelayCommand<string>(ExecuteSaveCommand);
        }

        private void LoadVaccines()
        {
            using (var context = new VaccinationManagementContext())
            {
                Vaccines = context.Vaccines.Where(x => x.IsActive.Value).ToList();
            }
        }

        private void LoadPackages()
        {
            using (var context = new VaccinationManagementContext())
            {
                Packages = context.VaccinationPackages
                 .Where(x => x.IsActive.Value)
                 .Select(s => new
                 {
                     s.PackageId,
                     s.Name,
                     s.Price,
                     s.Description,
                 })
                 .AsEnumerable() // Chuyển sang xử lý trên RAM
                 .Select(s => new VaccinationPackage
                 {
                     PackageId = s.PackageId,
                     Name = s.Name,
                     Price = s.Price,
                     Description = s.Description
                 })
                 .ToList();
            }
        }

        private void LoadAdministeredByUsers()
        {
            using (var context = new VaccinationManagementContext())
            {
                AdministeredByUsers = context.Staffs
                 .Where(x => x.IsActive)
                 .Select(s => new
                 {
                     s.StaffId,
                     s.FullName,
                     s.Phone,
                     s.Email
                 })
                 .AsEnumerable() // Chuyển sang xử lý trên RAM
                 .Select(s => new Staff
                 {
                     StaffId = s.StaffId,
                     FullName = s.FullName,
                     Phone = s.Phone,
                     Email = s.Email
                 })
                 .ToList();
            }
        }

        protected void ExecuteSaveCommand(string parameter)
        {
            _vaccinationRecord.ChildId = ((Children)FormState.Data).ChildId;
            _vaccinationRecord.CreatedAt = DateTime.Now;
            using (var context = new VaccinationManagementContext())
            {
                context.VaccinationRecords.Add(_vaccinationRecord);
                context.SaveChanges();
            }

            OnFormActionCallback();
        }
    }
}
