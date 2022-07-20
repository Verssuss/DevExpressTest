using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WpfApp3.Encrypting;
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //JsonSerializerSettings settings = new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //};
            //var res = JsonConvert.SerializeObject(new List<Employee> { new Administrator { Experience = 4, FullName = "Oleg", Login = "admin", Password = new RfcCrypt().HashPassword("admin"), Position = "Administrator", Salary = 2 } }, settings);

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
            {
                e.Handled = true;
            }
        }
    }
}