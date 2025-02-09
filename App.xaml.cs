using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VaccinationManagement.Data;
using VaccineManagement.Utils;

namespace VaccineManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoadingManager.Show("Đang khởi tạo ứng dụng...");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var loginForm = _serviceProvider.GetService(typeof(Login)) as Login;
            loginForm.Show();


            // Bắt các ngoại lệ không xử lý trong thread chính (UI thread)
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Bắt các ngoại lệ không xử lý trong thread khác (background threads)
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Bắt ngoại lệ không đồng bộ (async/await)
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            LoadingManager.Hide();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Login>();
            services.AddSingleton<MainWindow>();
            AddUserControl(services);

            services.AddScoped<VaccinationManagementContext>();
        }

        private void AddUserControl(IServiceCollection services)
        {
            var userControlTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(DevExpress.XtraEditors.XtraUserControl).IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();

            foreach (var type in userControlTypes)
            {
                services.AddTransient(type);
            }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Xử lý ngoại lệ UI
            //MessageBox.Show($"An error occurred: {e.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true; // Ngăn ứng dụng bị đóng
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Xử lý ngoại lệ trong AppDomain
            if (e.ExceptionObject is Exception ex)
            {
                //MessageBox.Show($"Critical error: {ex.Message}", "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Xử lý ngoại lệ không đồng bộ
            //MessageBox.Show($"Async error: {e.Exception.Message}", "Async Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.SetObserved(); // Đánh dấu ngoại lệ đã được xử lý
        }
    }
}
