using DevExpress.Data.Async.Helpers;
using DevExpress.Xpf.Core;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity.Infrastructure;
using System.Windows;
using VaccinationManagement.Data;
using VaccineManagement.Enum;
using VaccineManagement.Model;
using VaccineManagement.UserViewControl.Base;
using VaccineManagement.UserViewControl.ChildrenView;
using VaccineManagement.UserViewControl.VaccinationRecordView;

namespace VaccineManagement.UserViewControl
{
    public partial class ChildrenPage : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly VaccinationManagementContext _context;
        private string panelTitle = "Danh sách bệnh nhân";
        public ChildrenPage(VaccinationManagementContext context)
        {
            _context = context;
            InitializeComponent();
            InitializeGrid();
            CustomGridConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeGrid()
        {
            // Thiết lập InstantFeedbackSource
            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;

            // Thiết lập cơ bản cho grid
            var mainView = (GridView)gridControl.MainView;
            mainView.OptionsView.ShowGroupPanel = false;
            mainView.OptionsView.ShowIndicator = false;
            mainView.OptionsView.ShowAutoFilterRow = true;

            // xử lý disable các button trên barManager1
            barManager1.Items["btnEdit"].Enabled = false;
            barManager1.Items["btnDelete"].Enabled = false;
            barManager1.Items["btnView"].Enabled = false;
            barManager1.Items["btnInject"].Enabled = false;

            // xử lý khi nhấn sự kiện trên barManager1
            barManager1.ItemClick += BarManager1_ItemClick;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CustomGridConfig()
        {
            var mainView = (GridView)gridControl.MainView;

            // Ẩn các cột không cần thiết
            mainView.Columns[nameof(Children.VaccinationRecords)].Visible = false;
            mainView.Columns[nameof(Children.CreatedBy)].Visible = false;
            mainView.Columns[nameof(Children.CreatedByStaff)].Visible = false;
            mainView.Columns[nameof(Children.CreatedAt)].Visible = false;
            mainView.Columns[nameof(Children.UpdatedAt)].Visible = false;

            // Cấu hình cơ bản để cho phép edit
            mainView.OptionsView.ShowAutoFilterRow = true;
            mainView.OptionsSelection.EnableAppearanceFocusedCell = true;

            // add bar button
            mainView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            mainView.GridControl.UseEmbeddedNavigator = true;
            mainView.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            mainView.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

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
                barManager1.Items["btnView"].Enabled = false;
                barManager1.Items["btnInject"].Enabled = false;
                return;
            }
            barManager1.Items["btnEdit"].Enabled = true;
            barManager1.Items["btnDelete"].Enabled = true;
            barManager1.Items["btnView"].Enabled = true;
            barManager1.Items["btnInject"].Enabled = true;
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào các button trên barManager1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildrenPageEdit editForm = null;
            ChildrenPageViewModel pageViewModel = new ChildrenPageViewModel();
            // Lấy MainWindow và gọi OpenDocumentPanel
            var mainWindow = Application.Current.MainWindow as MainWindow;

            pageViewModel.FormActionCallback += (object senderAction, System.EventArgs eAction) =>
            {
                //editForm.Close();
                mainWindow.CloseDocumentPanel(panelTitle);
                ((IObjectContextAdapter)_context).ObjectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _context.Children);
                gridControl.RefreshDataSource();
                entityInstantFeedbackSource1.Refresh();
            };

            var mainView = (GridView)gridControl.MainView;
            var proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)(mainView.GetRow(mainView.FocusedRowHandle));

            switch (e.Item.Name)
            {
                case "btnAdd":
                    pageViewModel.FormState = new FormState
                    {
                        FormMode = FormMode.Add,
                    };
                    editForm = new ChildrenPageEdit(pageViewModel); // Xử lý thêm mới
                    panelTitle = "Thêm mới bệnh nhân";
                    mainWindow?.OpenDocumentPanel(panelTitle, null, editForm);
                    break;
                case "btnInject":
                    if (proxy != null)
                    {
                        var children = (Children)proxy.OriginalRow;
                        VaccinationRecordPageEdit vaccinationRecordPageEdit = new VaccinationRecordPageEdit();
                        VaccinationRecordViewModel vaccinationRecordViewModel = new VaccinationRecordViewModel
                        {
                            FormState = new FormState
                            {
                                FormMode = FormMode.Add,
                                Data = (Children)proxy.OriginalRow
                            }
                        };
                        vaccinationRecordPageEdit.DataContext = vaccinationRecordViewModel;
                        vaccinationRecordViewModel.FormActionCallback += (object senderAction, System.EventArgs eAction) =>
                        {
                            entityInstantFeedbackSource1.Refresh();
                            vaccinationRecordPageEdit.Close();
                        };
                        vaccinationRecordPageEdit.ShowDialog();
                    }
                    break;
                case "btnEdit":
                case "btnView":
                    if (proxy != null)
                    {
                        var children = (Children)proxy.OriginalRow;
                        pageViewModel.FormState = new FormState
                        {
                            FormMode = e.Item.Name == "btnView" ? FormMode.View : FormMode.Edit,
                            Data = children
                        };
                        panelTitle = (e.Item.Name == "btnView" ? "Chi tiết bệnh nhân" : "Sửa bệnh nhân") + $": {children.FullName}";
                        editForm = new ChildrenPageEdit(pageViewModel);
                        mainWindow?.OpenDocumentPanel(panelTitle, null, editForm);
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
                            var children = (Children)proxyDelete.OriginalRow;
                            _context.Children.Remove(children);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = _context.Children;
            e.Tag = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((VaccinationManagement.Data.VaccinationManagementContext)e.Tag).Dispose();
        }
    }
}