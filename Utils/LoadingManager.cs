using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System.Linq;
using System.Windows;

namespace VaccineManagement.Utils
{
    public static class LoadingManager
    {
        private static SplashScreenManager _indicator;

        private static Window GetActiveWindow()
        {
            return Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive)
                ?? Application.Current.MainWindow;
        }

        public static void Show(string message = "Đang xử lý...")
        {
            if (_indicator == null)
            {
                _indicator = SplashScreenManager.CreateWaitIndicator(
                    viewModel: new DXSplashScreenViewModel { Status = message }
                );
            }
            _indicator.Show(GetActiveWindow());
        }

        public static void Hide()
        {
            if (_indicator != null)
            {
                _indicator.Close();
                _indicator = null;
            }
        }
    }
}
