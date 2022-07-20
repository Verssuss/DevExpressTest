using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Expression = System.Linq.Expressions.Expression;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Items.Add(new Data() { ZIndex = 6, Name = "HOME" });
            Items.Add(new Data() { ZIndex = 5, Name = "ABOUT" });
            Items.Add(new Data() { ZIndex = 4, Name = "SERVICES" });
            Items.Add(new Data() { ZIndex = 3, Name = "PORTFOLIO" });
            Items.Add(new Data() { ZIndex = 2, Name = "OUR TEAM" });

            DataContext = this;
        }

        public List<Data> Items { get; set; } = new List<Data>();
    }
    public struct Data
    {
        public int ZIndex { get; set; }
        public string Name { get; set; }
        public bool DropShadow { get; set; }
    }
}
