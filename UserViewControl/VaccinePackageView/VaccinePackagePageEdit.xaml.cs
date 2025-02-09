using System.Windows;
using VaccineManagement.Enum;
namespace VaccineManagement.UserViewControl.VaccinePackageView
{
    /// <summary>
    /// Interaction logic for VaccinePackagePageEdit.xaml
    /// </summary>
    public partial class VaccinePackagePageEdit : Window
    {
        public VaccinePackagePageEdit(VaccinePackagePageViewModel pageViewModel)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = pageViewModel;

            switch (pageViewModel.FormState.FormMode)
            {
                case FormMode.Add:
                    Title = "Thêm mới vaccine";
                    break;
                case FormMode.Edit:
                    Title = "Sửa vaccine";
                    break;
            }

        }
    }
}
