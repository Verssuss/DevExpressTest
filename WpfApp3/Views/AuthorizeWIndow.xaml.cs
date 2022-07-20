using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.ViewModels;

namespace WpfApp3.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizeWIndow.xaml
    /// </summary>
    public partial class AuthorizeWIndow : Window
    {
        public AuthorizeWIndow()
        {
            InitializeComponent();
        }

        

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthorizeViewModel vm)
                vm.Password = passwordBox.Password;
        }
    }
}
