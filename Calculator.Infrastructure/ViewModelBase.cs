using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Calculator.Infrastructure
{
    public class ViewModelBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors;

        public ViewModelBase()
        {
            _errors = new Dictionary<string, List<string>>();
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                foreach (var error in _errors[propertyName])
                {
                    yield return error;
                }
            }
        }

        public void AddError(string error, [CallerMemberName]string propertyName = null)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Add(error);
            }
            else
            {
                _errors[propertyName] = new List<string> { error };
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void RemoveError([CallerMemberName]string propertyName = null)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);

                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
