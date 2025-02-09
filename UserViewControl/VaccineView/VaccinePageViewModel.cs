using System;
using System.Windows.Input;
using VaccinationManagement.Data;
using VaccineManagement.Command;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;

namespace VaccineManagement.UserViewControl.VaccineView
{
    public class VaccinePageViewModel : BaseViewModel
    {

        public ICommand SaveCommand { get; private set; }

        private Vaccine _vaccine;
        public Vaccine Vaccine
        {
            get { return _vaccine; }
            set
            {
                if (_vaccine != value)
                {
                    _vaccine = value;
                    OnPropertyChanged(nameof(Vaccine));
                }
            }
        }

        public VaccinePageViewModel()
        {
            SaveCommand = new RelayCommand<string>(ExecuteSaveCommand);
        }

        public override void FormSateChange()
        {
            if (FormState.FormMode == FormMode.Add)
            {
                _vaccine = new Model.Vaccine()
                {
                    IsActive = true
                };
            }

            if (FormState.FormMode == FormMode.Edit)
            {
                var vaccine = (Model.Vaccine)FormState.Data;
                using (var db = new VaccinationManagementContext())
                {
                    _vaccine = db.Vaccines.Find(vaccine.VaccineId);
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
                        _vaccine.CreatedAt = DateTime.Now;
                        db.Vaccines.Add(_vaccine);
                        break;
                    case FormMode.Edit:
                        _vaccine.UpdatedAt = DateTime.Now;
                        db.Vaccines.Attach(_vaccine);
                        db.Entry(_vaccine).State = System.Data.Entity.EntityState.Modified;
                        break;
                }

                db.SaveChanges();
            }

            OnFormActionCallback();
        }
    }
}
