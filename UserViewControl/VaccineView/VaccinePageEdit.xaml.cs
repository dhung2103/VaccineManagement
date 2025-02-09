﻿using System.Windows;
using VaccineManagement.Enum;
namespace VaccineManagement.UserViewControl.VaccineView
{
    /// <summary>
    /// Interaction logic for VaccinePageEdit.xaml
    /// </summary>
    public partial class VaccinePageEdit : Window
    {
        public VaccinePageEdit(VaccinePageViewModel pageViewModel)
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
