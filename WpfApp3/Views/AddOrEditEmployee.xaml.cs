using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using WpfApp3.Common;
using WpfApp3.Enums;
using WpfApp3.Extensions;
using WpfApp3.Models;

namespace WpfApp3.Views
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditEmployee.xaml
    /// </summary>
    public partial class AddOrEditEmployee : Window
    {
        public AddOrEditEmployee()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<Position> Positions { get; set; } = new EnumerableEnum<Position>().Cast<Position>().ToList();

        public int SelectedIndex { get; set; } 

        public Employee Employee { get; set; }

        public AddOrEditEmployee(Employee employee) : this()
        {
            Employee = employee;
            SelectedIndex = (int)Positions.FirstOrDefault(x => x.GetEnumTextValue() == employee.Position);
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog res = new OpenFileDialog();

            res.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;";

            if (res.ShowDialog() == true)
            {
                var filePath = res.FileName;
                Employee.PhotoSource = filePath;
            }
        }
    }
}
