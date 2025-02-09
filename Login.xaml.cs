using DevExpress.Xpf.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Entity;
using System.Windows;
using VaccinationManagement.Data;
using VaccineManagement.Session;
using VaccineManagement.Utils;

namespace VaccineManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : ThemedWindow
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly VaccinationManagementContext _context;
        public Login(IServiceProvider serviceProvider, VaccinationManagementContext context)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = context;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingManager.Show("Đang đăng nhập...");
            var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.Username == UsernameTextBox.Text && x.PasswordHash == PasswordBox.Password);
            if (staff != null)
            {
                if (!staff.IsActive)
                {
                    DXMessageBox.Show("Tài khoản của bạn đã bị khóa", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoadingManager.Hide();
                    return;
                }

                UserSession.Instance.User = staff;
                var mainWindow = _serviceProvider.GetService<MainWindow>();
                mainWindow.Show();
                Application.Current.MainWindow = mainWindow; // Gán MainWindow
                Close();
            }
            else
            {
                DXMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadingManager.Hide();
        }
    }
}
