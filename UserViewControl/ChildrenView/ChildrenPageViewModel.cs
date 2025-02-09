using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VaccinationManagement.Data;
using VaccineManagement.Command;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.Session;
using VaccineManagement.UserViewControl.Base;

namespace VaccineManagement.UserViewControl.ChildrenView
{
    public class ChildrenPageViewModel : BaseViewModel
    {
        public List<string> GenderList { get; } = new List<string> { "Nam", "Nữ", "Khác" };
        public ICommand SaveCommand { get; private set; }

        private Children _children;
        public Children Children
        {
            get { return _children; }
            set
            {
                if (_children != value)
                {
                    _children = value;
                    OnPropertyChanged(nameof(Children));
                }
            }
        }

        public ChildrenPageViewModel()
        {
            SaveCommand = new RelayCommand<string>(ExecuteSaveCommand);
        }

        public override void FormSateChange()
        {
            if (FormState.FormMode == FormMode.Add)
            {
                _children = new Model.Children()
                {
                    DateOfBirth = DateTime.Now,
                    Gender = "Nam"
                };
            }

            if (FormState.FormMode == FormMode.Edit)
            {
                using (var db = new VaccinationManagementContext())
                {
                    _children = db.Children.Find(((Model.Children)FormState.Data).ChildId);
                }
            }

            if (FormState.FormMode == FormMode.View)
            {
                using (var db = new VaccinationManagementContext())
                {
                    _children = db.Children
                             .Include("VaccinationRecords")
                             ?.Include("VaccinationRecords.Vaccine")
                             ?.Include("VaccinationRecords.Package")
                             ?.Include("VaccinationRecords.AdministeredByStaff")
                             .Where(x => x.ChildId == ((Model.Children)FormState.Data).ChildId)
                             .FirstOrDefault();
                }
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
                        _children.CreatedAt = DateTime.Now;
                        _children.CreatedBy = UserSession.Instance.User.StaffId;
                        db.Children.Add(_children);
                        break;
                    case FormMode.Edit:
                        _children.UpdatedAt = DateTime.Now;
                        db.Children.Attach(_children);
                        db.Entry(_children).State = System.Data.Entity.EntityState.Modified;
                        break;
                }

                db.SaveChanges();
            }

            OnFormActionCallback();
        }
    }
}
