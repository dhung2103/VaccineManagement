using DevExpress.Data.Async.Helpers;
using DevExpress.Xpf.Core;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using VaccinationManagement.Data;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;
using VaccineManagement.UserViewControl.VaccinePackageView;
using VaccineManagement.Utils;

namespace VaccineManagement.UserViewControl
{
    public partial class VaccinePackagePage : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly VaccinationManagementContext _context;
        public VaccinePackagePage(VaccinationManagementContext context)
        {
            _context = context;
            InitializeComponent();

            this.entityInstantFeedbackSource1.GetQueryable += EntityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += EntityInstantFeedbackSource1_DismissQueryable;
            this.entityInstantFeedbackSource1.DefaultSorting = "PackageId DESC";

            // Thiết lập cơ bản cho grid
            var mainView = (GridView)gridControl.MainView;
            mainView.OptionsView.ShowGroupPanel = false;
            mainView.OptionsView.ShowIndicator = false;
            mainView.OptionsView.ShowAutoFilterRow = true;

            // Configure master-detail
            GridView detailView = new GridView(gridControl)
            {
                ViewCaption = "Chi tiết gói tiêm",
            };
            gridControl.ViewCollection.Add(detailView);
            mainView.DetailHeight = 400;
            mainView.OptionsDetail.ShowDetailTabs = true;

            // ẩn cột không cần thiết
            mainView.Columns[nameof(VaccinationPackage.PackageVaccines)].Visible = false;
            mainView.Columns[nameof(VaccinationPackage.VaccinationRecords)].Visible = false;
            mainView.Columns[nameof(VaccinationPackage.CreatedAt)].Visible = false;
            mainView.Columns[nameof(VaccinationPackage.UpdatedAt)].Visible = false;

            // xử lý disable các button trên barManager1
            barManager1.Items["btnEdit"].Enabled = false;
            barManager1.Items["btnDelete"].Enabled = false;

            mainView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            mainView.GridControl.UseEmbeddedNavigator = true;
            mainView.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

            mainView.MasterRowGetChildList += MasterRowGetChildList;
            mainView.MasterRowExpanded += MasterRowExpanded;
            mainView.MasterRowGetRelationCount += MasterRowGetRelationCount;
            mainView.FocusedRowChanged += MainView_FocusedRowChanged;
            barManager1.ItemClick += BarManager1_ItemClick;
        }

        /// <summary>
        /// Xử lý sự kiện khi focus vào một row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var mainView = (GridView)gridControl.MainView;
            var selectedRow = mainView.GetFocusedRow();
            if (selectedRow == null)
            {
                barManager1.Items["btnEdit"].Enabled = false;
                barManager1.Items["btnDelete"].Enabled = false;
                return;
            }
            barManager1.Items["btnEdit"].Enabled = true;
            barManager1.Items["btnDelete"].Enabled = true;
        }

        private void BarManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VaccinePackagePageEdit editForm = null;
            VaccinePackagePageViewModel pageViewModel = new VaccinePackagePageViewModel();
            pageViewModel.FormActionCallback += (object senderAction, System.EventArgs eAction) =>
            {
                editForm.Close();
                ((IObjectContextAdapter)_context).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _context.VaccinationPackages);
                gridControl.RefreshDataSource();
                entityInstantFeedbackSource1.Refresh();
            };

            switch (e.Item.Name)
            {
                case "btnAdd":
                    pageViewModel.FormState = new FormState
                    {
                        FormMode = FormMode.Add,
                    };
                    editForm = new VaccinePackagePageEdit(pageViewModel); // Xử lý thêm mới
                    editForm.ShowDialog();
                    break;
                case "btnEdit":
                    var mainView = (GridView)gridControl.MainView;
                    var proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)(mainView.GetRow(mainView.FocusedRowHandle));
                    if (proxy != null)
                    {
                        pageViewModel.FormState = new FormState
                        {
                            FormMode = FormMode.Edit,
                            Data = proxy.OriginalRow
                        };
                        editForm = new VaccinePackagePageEdit(pageViewModel);
                        editForm.ShowDialog();
                    }
                    break;
                case "btnDelete":
                    // confirm before delete
                    if (DXMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var mainViewDelete = (GridView)gridControl.MainView;
                        var proxyDelete = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)(mainViewDelete.GetRow(mainViewDelete.FocusedRowHandle));
                        if (proxyDelete != null)
                        {
                            var vp = (VaccinationPackage)proxyDelete.OriginalRow;
                            _context.Database.BeginTransaction();
                            try
                            {
                                // xóa trong bảng PackageVaccine
                                var packageVaccines = _context.PackageVaccines.Where(pv => pv.PackageId == vp.PackageId).ToList();
                                _context.PackageVaccines.RemoveRange(packageVaccines);

                                // xóa trong bảng VaccinationPackage
                                _context.VaccinationPackages.Remove(vp);

                                _context.SaveChanges();
                                _context.Database.CurrentTransaction.Commit();
                                entityInstantFeedbackSource1.Refresh();
                            }
                            catch (System.Exception ex)
                            {
                                _context.Database.CurrentTransaction.Rollback();
                                DXMessageBox.Show("Không thể xóa bản ghi này do đã có dữ liệu liên quan đến nó.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    break;
                case "btnRefresh":
                    // Xử lý refresh
                    entityInstantFeedbackSource1.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)((GridView)sender).GetRow(e.RowHandle);
            var package = proxy.OriginalRow as VaccinationPackage;
            if (package != null)
            {
                LoadingManager.Show("Đang tải dữ liệu...");

                // Lấy dữ liệu vaccines
                var vaccines = _context.PackageVaccines
                    .Include("Vaccine")
                    .Where(pv => pv.PackageId == package.PackageId && pv.Vaccine.IsActive.Value)
                    .OrderBy(x => x.DoseOrder)
                    .Select(pv => new
                    {
                        pv.VaccineId,
                        pv.Vaccine.Name,
                        pv.Vaccine.Manufacturer,
                        pv.Vaccine.Description,
                        pv.Vaccine.MinAgeMonths,
                        pv.Vaccine.MaxAgeMonths,
                        pv.Vaccine.DosageInfo,
                        pv.Vaccine.Price,
                        pv.Vaccine.IsActive,
                    })
                    .ToList();

                e.ChildList = vaccines.Select(pv => new Vaccine
                {
                    VaccineId = pv.VaccineId,
                    Name = pv.Name,
                    Manufacturer = pv.Manufacturer,
                    Description = pv.Description,
                    MinAgeMonths = pv.MinAgeMonths,
                    MaxAgeMonths = pv.MaxAgeMonths,
                    DosageInfo = pv.DosageInfo,
                    Price = pv.Price,
                    IsActive = pv.IsActive,
                }).ToList();

                LoadingManager.Hide();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView masterView = sender as GridView;
            if (masterView.GetDetailView(e.RowHandle, e.RelationIndex) is GridView detailView)
            {
                detailView.Columns[nameof(Vaccine.CreatedAt)].Visible = false;
                detailView.Columns[nameof(Vaccine.UpdatedAt)].Visible = false;
                detailView.Columns[nameof(Vaccine.PackageVaccines)].Visible = false;
                detailView.Columns[nameof(Vaccine.VaccinationRecords)].Visible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EntityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = _context.VaccinationPackages;
            e.Tag = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EntityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((VaccinationManagement.Data.VaccinationManagementContext)e.Tag).Dispose();
        }
    }
}
