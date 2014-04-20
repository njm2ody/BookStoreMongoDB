
using System;
using System.Collections.Generic;

using System.ComponentModel;

namespace GUI
{
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected ViewModelBase()
        {
            _errors = new Dictionary<string, string>();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;




        protected IDictionary<string, string> _errors;

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                return _errors.ContainsKey(columnName) ? _errors[columnName] : null;
            }
        }

        protected void AddError(string error, string property)
        {
            if (!_errors.ContainsKey(property))
            {
                _errors.Add(property, error);
            }
        }

        protected void RemoveError(string property)
        {
            if (_errors.ContainsKey(property))
            {
                _errors.Remove(property);
            }
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
