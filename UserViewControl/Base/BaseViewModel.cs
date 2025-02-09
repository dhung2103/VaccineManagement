using DevExpress.Mvvm;
using System;
using System.ComponentModel;
using VaccineManagement.Enum;

namespace VaccineManagement.UserViewControl.Base
{
    public class FormState
    {
        public FormMode FormMode { get; set; }
        public object Data { get; set; }
    }

    public class BaseViewModel : ViewModelBase
    {
        private FormState _formState;
        public FormState FormState
        {
            get { return _formState; }
            set
            {
                _formState = value;
                OnPropertyChanged(nameof(FormState));
                FormSateChange();
            }
        }

        public bool IsViewMode => FormState.FormMode == FormMode.View;

        public virtual void FormSateChange()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler FormActionCallback;
        protected virtual void OnFormActionCallback()
        {
            FormActionCallback?.Invoke(this, EventArgs.Empty);
        }
    }
}
