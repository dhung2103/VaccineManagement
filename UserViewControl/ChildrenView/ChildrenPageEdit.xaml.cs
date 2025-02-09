using DevExpress.Xpf.Grid;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using VaccineManagement.Enum;
namespace VaccineManagement.UserViewControl.ChildrenView
{
    public class StringTrimmingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text && parameter is int maxLength)
            {
                if (text.Length > maxLength)
                {
                    return text.Substring(0, maxLength) + "...";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for ChildrenPageEdit.xaml
    /// </summary>
    public partial class ChildrenPageEdit : UserControl
    {
        public ChildrenPageEdit(ChildrenPageViewModel pageViewModel)
        {
            InitializeComponent();
            //WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = pageViewModel;

            switch (pageViewModel.FormState.FormMode)
            {
                case FormMode.Add:
                    leftPanel.Visibility = Visibility.Collapsed;
                    break;
                case FormMode.Edit:
                    leftPanel.Visibility = Visibility.Collapsed;
                    break;
                case FormMode.View:
                    btnSave.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void Grid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.FieldName == "ChildId" ||
                e.Column.FieldName == "Child" ||
                e.Column.FieldName == "Vaccine" ||
                e.Column.FieldName == "Package" ||
                e.Column.FieldName == "HealthScreening" ||
                e.Column.FieldName == "CreatedAt" ||
                e.Column.FieldName == "AdministeredByStaff"
            )
            {
                e.Column.Visible = false;
            }
            else
            {
                if (e.Column is DevExpress.Xpf.Grid.GridColumn gridColumn)
                {
                    e.Column.Width = 200;
                    e.Column.CellToolTipBinding = new Binding(e.Column.FieldName)
                    {
                        Converter = new StringTrimmingConverter(),
                        ConverterParameter = 50
                    };
                }
            }
        }
    }
}
