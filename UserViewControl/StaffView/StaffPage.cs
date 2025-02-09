using DevExpress.Data.Async.Helpers;
using DevExpress.Xpf.Core;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity.Infrastructure;
using System.Windows;
using VaccinationManagement.Data;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;
using VaccineManagement.UserViewControl.StaffView;

namespace VaccineManagement.UserViewControl
{
    public partial class StaffPage : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly VaccinationManagementContext _context;

        public StaffPage(VaccinationManagementContext context)
        {
            _context = context;
            InitializeComponent();
            InitializeGrid();
            CustomGridConfig();
        }

        private void InitializeGrid()
        {
            // Thiết lập cơ bản cho grid
            var mainView = (GridView)gridControl.MainView;
            mainView.OptionsView.ShowGroupPanel = false;
            mainView.OptionsView.ShowIndicator = false;
            mainView.OptionsView.ShowAutoFilterRow = true;

            this.entityInstantFeedbackSource1.GetQueryable += EntityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += EntityInstantFeedbackSource1_DismissQueryable;

            // xử lý disable các button trên barManager1
            barManager1.Items["btnEdit"].Enabled = false;
            barManager1.Items["btnDelete"].Enabled = false;

            // xử lý khi nhấn sự kiện trên barManager1
            barManager1.ItemClick += BarManager1_ItemClick;
        }

        private void CustomGridConfig()
        {
            var mainView = (GridView)gridControl.MainView;

            // Ẩn các cột không cần thiết
            mainView.Columns[nameof(Staff.VaccinationRecords)].Visible = false;
            mainView.Columns[nameof(Staff.CreatedChildren)].Visible = false;
            mainView.Columns[nameof(Staff.PasswordHash)].Visible = false;
            mainView.Columns[nameof(Staff.CreatedAt)].Visible = false;
            mainView.Columns[nameof(Staff.UpdatedAt)].Visible = false;

            // Cấu hình cơ bản để cho phép edit
            mainView.OptionsView.ShowAutoFilterRow = true;
            mainView.OptionsSelection.EnableAppearanceFocusedCell = true;

            // Cấu hình các column
            foreach (GridColumn column in mainView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;  // Cho phép edit từng cột
                column.OptionsColumn.ReadOnly = false;
            }

            // add bar button
            mainView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            mainView.GridControl.UseEmbeddedNavigator = true;
            mainView.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

            // gridView_CustomColumnDisplayText
            mainView.CustomColumnDisplayText += CustomColumnDisplayText;
            // xử lý khi chọn row
            mainView.FocusedRowChanged += MainView_FocusedRowChanged;
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
            StaffPageEdit editForm = null;
            StaffPageViewModel pageViewModel = new StaffPageViewModel();
            pageViewModel.FormActionCallback += (object senderAction, System.EventArgs eAction) =>
            {
                editForm.Close();
                ((IObjectContextAdapter)_context).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _context.Staffs);
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
                    editForm = new StaffPageEdit(pageViewModel); // Xử lý thêm mới
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
                        editForm = new StaffPageEdit(pageViewModel);
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
                            var staff = (Staff)proxyDelete.OriginalRow;
                            _context.Staffs.Remove(staff);
                            try
                            {
                                _context.SaveChanges();
                                entityInstantFeedbackSource1.Refresh();
                            }
                            catch (System.Exception ex)
                            {
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

        // This event is generated by Data Source Configuration Wizard
        void EntityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = _context.Staffs;
            e.Tag = _context;
        }

        void EntityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((VaccinationManagement.Data.VaccinationManagementContext)e.Tag).Dispose();
        }

        private void CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == nameof(Staff.Role))
            {
                switch (e.Value)
                {
                    case "Admin":
                        e.DisplayText = "Quản trị";
                        break;
                    case "Staff":
                        e.DisplayText = "Nhân viên y tế";
                        break;
                }
            }
        }
    }
}