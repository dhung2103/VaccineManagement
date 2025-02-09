using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Layout.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using VaccineManagement.Session;
using VaccineManagement.UserViewControl;
using VaccineManagement.Utils;
namespace VaccineManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        private IServiceProvider _serviceProvider;
        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            DockLayoutManager.ClosingBehavior = ClosingBehavior.ImmediatelyRemove;
            this.Closing += MainWindow_Closing;

            if (!string.Equals(UserSession.Instance.User.Role, "admin", StringComparison.OrdinalIgnoreCase))
            {
                employeeRibbonPage.IsVisible = false;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = DXMessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                       MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Mở trang danh sách gói tiêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VaccinePackageItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            OpenDocumentPanel("Gói tiêm", typeof(VaccinePackagePage));
        }

        /// <summary>
        /// Mở trang danh sách vaccine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VaccineItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            OpenDocumentPanel("Vaccine", typeof(VaccinePage));
        }

        /// <summary>
        /// Mở trang danh sách nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            OpenDocumentPanel("Danh sách nhân viên", typeof(StaffPage));
        }

        /// <summary>
        /// Mở trang danh sách bệnh nhân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void childrenItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            OpenDocumentPanel("Danh sách bệnh nhân", typeof(ChildrenPage));
        }

        /// <summary>
        /// Xử lý tạo mới một cửa sổ DocumentPanel
        /// </summary>
        /// <param name="panelCaption"></param>
        /// <param name="controlType"></param>
        /// <param name="customControl"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void OpenDocumentPanel(string panelCaption, Type controlType = null, UserControl customControl = null)
        {
            // Kiểm tra xem cửa sổ đã mở chưa
            var tabs = DockLayoutManager.GetItems();
            var tab = tabs.OfType<DocumentPanel>().FirstOrDefault(x => panelCaption.Equals(x.Caption));
            if (tab != null)
            {
                tab.IsActive = true;
                return;
            }

            // Lấy DocumentGroup hiện có hoặc tạo mới
            var documentGroup = DocumentsGroup.Items
                .OfType<DocumentGroup>()
                .FirstOrDefault() ?? new DocumentGroup();

            // Nếu là nhóm mới, thêm vào DocumentsGroup
            if (!DocumentsGroup.Items.Contains(documentGroup))
            {
                DockLayoutManager.DockController.Dock(documentGroup, DocumentsGroup, DockType.Fill);
            }

            // Vô hiệu hóa chia tách
            documentGroup.AllowSplitters = false;

            // Tạo và cấu hình DocumentPanel
            var documentPanel = DockLayoutManager.DockController.AddDocumentPanel(documentGroup);
            documentPanel.Caption = panelCaption;
            DockLayoutManager.DockController.Dock(documentPanel, documentGroup, DockType.Fill);
            LoadingManager.Show("Đang tải dữ liệu...");

            try
            {
                if (customControl != null)
                {
                    customControl.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    customControl.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    documentPanel.Content = customControl;
                    return;
                }

                if (controlType != null)
                {
                    // Kiểm tra xem controlType có phải là UserControl WPF không
                    if (typeof(System.Windows.Controls.UserControl).IsAssignableFrom(controlType))
                    {
                        var control = Activator.CreateInstance(controlType) as System.Windows.Controls.UserControl;
                        documentPanel.Content = control;
                    }
                    // Kiểm tra xem controlType có phải là Windows Forms UserControl không
                    else if (typeof(System.Windows.Forms.UserControl).IsAssignableFrom(controlType))
                    {
                        var host = new WindowsFormsHost();
                        var control = _serviceProvider.GetService(controlType) as System.Windows.Forms.UserControl ?? throw new InvalidOperationException($"Could not create control of type {controlType.Name}");
                        host.Child = control;
                        documentPanel.Content = host;
                    }
                    else
                    {
                        throw new ArgumentException("Unsupported control type. Must be either WPF UserControl or Windows Forms UserControl.");
                    }
                }
                else
                {
                    throw new ArgumentException("Either controlType or customControl must be provided.");
                }
            }
            finally
            {
                LoadingManager.Hide();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="panelCaption"></param>
        public void CloseDocumentPanel(string panelCaption)
        {
            var tabs = DockLayoutManager.GetItems();
            var tab = tabs.OfType<DocumentPanel>().FirstOrDefault(x => panelCaption.Equals(x.Caption));

            if (tab != null)
            {
                DockLayoutManager.DockController.Close(tab);
            }
        }
    }
}
