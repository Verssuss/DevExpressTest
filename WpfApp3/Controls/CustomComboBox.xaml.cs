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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Enums;
using WpfApp3.Extensions;

namespace WpfApp3.Controls
{
    /// <summary>
    /// Логика взаимодействия для CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : UserControl
    {
        public CustomComboBox()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.Language = new System.Globalization.CultureInfo((comboBox.SelectedItem as Collections.Language).Lang.GetEnumTextValue());
        }

    }
}
