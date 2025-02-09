using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccinationManagement.Data;
using VaccineManagement.Command;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;

namespace VaccineManagement.UserViewControl.StaffView
{
    public class RoleItem
    {
        public string Key { get; set; }    // admin, staff, user...
        public string Value { get; set; }  // Quản trị hệ thống, Nhân viên...
    }

    public class StaffPageViewModel : BaseViewModel
    {
        public ObservableCollection<RoleItem> RoleList { get; set; } = new ObservableCollection<RoleItem>
        {
            new RoleItem { Key = "Admin", Value = "Quản trị hệ thống" },
            new RoleItem { Key = "Staff", Value = "Nhân viên y tế" },
        };

        private string _selectedRole;
        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                    OnPropertyChanged(nameof(SelectedRole));
                }
            }
        }

        public ICommand SaveCommand { get; private set; }

        private Staff _staff;
        public Staff Staff
        {
            get { return _staff; }
            set
            {
                if (_staff != value)
                {
                    _staff = value;
                    OnPropertyChanged(nameof(Staff));
                }
            }
        }

        public StaffPageViewModel()
        {
            SaveCommand = new RelayCommand<string>(ExecuteSaveCommand);
        }

        public override void FormSateChange()
        {
            if (FormState.FormMode == FormMode.Add)
            {
                _staff = new Model.Staff();
                SelectedRole = RoleList[1].Key;
            }

            if (FormState.FormMode == FormMode.Edit)
            {
                _staff = (Model.Staff)FormState.Data;
                SelectedRole = _staff.Role;
            }
        }

        // Thực thi khi command được gọi
        protected void ExecuteSaveCommand(string parameter)
        {
            using (var db = new VaccinationManagementContext())
            {
                switch (FormState.FormMode)
                {
                    case FormMode.Add:
                        _staff.CreatedAt = DateTime.Now;
                        _staff.Role = SelectedRole;
                        db.Staffs.Add(_staff);
                        break;
                    case FormMode.Edit:
                        _staff.UpdatedAt = DateTime.Now;
                        _staff.Role = SelectedRole;
                        db.Staffs.Attach(_staff);
                        db.Entry(_staff).State = System.Data.Entity.EntityState.Modified;
                        break;
                }

                db.SaveChanges();
                db.ChangeTracker.DetectChanges();
            }

            OnFormActionCallback();
        }
    }
}
