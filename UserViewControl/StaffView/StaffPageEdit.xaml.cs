using System.Windows;
using VaccineManagement.Enum;
namespace VaccineManagement.UserViewControl.StaffView
{
    /// <summary>
    /// Interaction logic for StaffPageEdit.xaml
    /// </summary>
    public partial class StaffPageEdit : Window
    {
        public StaffPageEdit(StaffPageViewModel pageViewModel)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = pageViewModel;

            switch (pageViewModel.FormState.FormMode)
            {
                case FormMode.Add:
                    Title = "Thêm mới nhân viên";
                    break;
                case FormMode.Edit:
                    Title = "Sửa nhân viên";
                    break;
            }
        }
    }
}
