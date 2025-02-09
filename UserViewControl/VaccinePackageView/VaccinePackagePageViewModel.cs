using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using VaccinationManagement.Data;
using VaccineManagement.Command;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;

namespace VaccineManagement.UserViewControl.VaccinePackageView
{
    public class VaccinePackagePageViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get; private set; }

        private VaccinationPackage _vaccinePackage;
        public VaccinationPackage VaccinePackage
        {
            get { return _vaccinePackage; }
            set
            {
                if (_vaccinePackage != value)
                {
                    _vaccinePackage = value;
                    OnPropertyChanged(nameof(VaccinePackage));
                }
            }
        }
        public ObservableCollection<PackageVaccine> VaccineList { get; set; }
        public ObservableCollection<Vaccine> AllVaccines { get; set; }

        public VaccinePackagePageViewModel()
        {
            SaveCommand = new RelayCommand<string>(ExecuteSaveCommand);
            DeleteVaccineCommand = new RelayCommand<DevExpress.Xpf.Grid.EditGridCellData>(DeleteVaccine);

            using (var db = new VaccinationManagementContext())
            {
                var sc = db.Vaccines.Where(x => x.IsActive.Value).ToList().Select(x => new Vaccine
                {
                    VaccineId = x.VaccineId,
                    Name = x.Name,
                    Price = x.Price,
                });

                AllVaccines = new ObservableCollection<Vaccine>(sc);
            }

            // Khởi tạo danh sách vaccine trong gói tiêm
            VaccineList = new ObservableCollection<PackageVaccine>();

            // nếu VaccineList thay đổi thì tính lại giá tiền
            VaccineList.CollectionChanged += (sender, e) =>
            {
                VaccinePackage.Price = VaccineList.Sum(x => x.Price);

                // Cập nhật số thứ tự liều tiêm
                for (int i = 0; i < VaccineList.Count; i++)
                {
                    VaccineList[i].DoseOrder = i + 1;
                }
            };
        }


        public override void FormSateChange()
        {
            if (FormState.FormMode == FormMode.Add)
            {
                _vaccinePackage = new Model.VaccinationPackage()
                {
                    IsActive = true,
                };
            }

            if (FormState.FormMode == FormMode.Edit)
            {
                _vaccinePackage = (Model.VaccinationPackage)FormState.Data;

                // lấy ra PackageVaccines
                using (var db = new VaccinationManagementContext())
                {
                    var package = db.VaccinationPackages
                        .Include("PackageVaccines")
                        .Where(x => x.PackageId == _vaccinePackage.PackageId)
                        ?.FirstOrDefault();

                    if (package != null)
                    {
                        _vaccinePackage = package;
                        VaccineList.Clear();
                        package.PackageVaccines.ForEach(x => VaccineList.Add(x));
                    }
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
                        _vaccinePackage.CreatedAt = DateTime.Now;
                        _vaccinePackage.PackageVaccines = VaccineList;
                        db.VaccinationPackages.Add(_vaccinePackage);
                        break;
                    case FormMode.Edit:
                        var existingPackage = db.VaccinationPackages
                            .Include(p => p.PackageVaccines)
                            .FirstOrDefault(p => p.PackageId == _vaccinePackage.PackageId);

                        if (existingPackage != null)
                        {
                            db.Entry(existingPackage).CurrentValues.SetValues(_vaccinePackage);
                            existingPackage.UpdatedAt = DateTime.Now;

                            // Xóa vaccine cũ
                            existingPackage.PackageVaccines.Clear();

                            // Thêm vaccine mới
                            foreach (var pv in VaccineList)
                            {
                                existingPackage.PackageVaccines.Add(new PackageVaccine
                                {
                                    VaccineId = pv.VaccineId,
                                    Price = pv.Price,
                                    DoseOrder = pv.DoseOrder
                                });
                            }
                        }
                        break;
                }

                db.SaveChanges();
            }

            OnFormActionCallback();
        }

        [Command]
        public void AddNewVaccineCommand(NewRowArgs args)
        {
            args.Item = new PackageVaccine();
        }

        [Command]
        public void CellValueChangedCommand(CellValueChangedArgs args)
        {
            if (args.FieldName == "VaccineId" && args.Value != null)
            {
                var vaccine = AllVaccines.FirstOrDefault(x => x.VaccineId == (int)args.Value);
                var packageVaccine = args.Item as PackageVaccine;

                if (vaccine != null && packageVaccine != null)
                {
                    packageVaccine.Price = vaccine.Price;
                }
            }

            VaccinePackage.Price = VaccineList.Sum(x => x.Price);
        }

        public ICommand DeleteVaccineCommand { get; set; }
        private void DeleteVaccine(DevExpress.Xpf.Grid.EditGridCellData cellData)
        {
            var vaccine = cellData.Row as PackageVaccine;
            if (vaccine != null)
            {
                VaccineList.Remove(vaccine);
            }
        }
    }
}
