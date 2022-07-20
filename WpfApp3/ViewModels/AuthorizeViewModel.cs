using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp3.Encrypting;
using WpfApp3.Models;
using WpfApp3.Repositories;

namespace WpfApp3.ViewModels
{
    public class AuthorizeViewModel : ObservableObject
    {

        public AuthorizeViewModel(ICrypted crypted, IDataStore<Employee> dataStore)
        {
            _crypted = crypted;
            _dataStore = dataStore;
            AuthorizeCommand = new RelayCommand(Authorize, () => new string[] { Login, Password }.All(x => !string.IsNullOrEmpty(x)));
        }
        public RelayCommand AuthorizeCommand { get; set; }

        public bool VisibleSignMessage { get; set; }

        public async void Authorize()
        {
            if (IsBusy) return;

            IsBusy = true;

            //Имитация авторизации
            await Task.Delay(3000);

            var items = await _dataStore.GetAllAsync();
            var employee = items.FirstOrDefault(e => e is Administrator admin && admin.Login == Login) as Administrator;
            bool result = false;
            if (employee != null)
            {
                result = _crypted.VerifyHashedPassword(employee.Password, Password);
                if (result)
                {
                    new MainWindow().Show();
                }
            }

            if (employee == null || result == false)
            {
                Task.Run(async () =>
                {
                    VisibleSignMessage = true;
                    await Task.Delay(3000);
                    VisibleSignMessage = false;
                });
            }

            IsBusy = false;
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                SetProperty(ref _login, value);
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }
        public bool IsBusy { get; set; }

        private ICrypted _crypted;
        private readonly IDataStore<Employee> _dataStore;

    }
}
