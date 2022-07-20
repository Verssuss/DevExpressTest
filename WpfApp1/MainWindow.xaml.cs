using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IMessenger, MessengerControl>();

            var provider = services.BuildServiceProvider();

            messenger = provider.GetService<IMessenger>();

            if (messenger is UIElement ui)
                grid.Children.Add(ui);
        }
        IMessenger messenger;

        private async void Success(object sender, RoutedEventArgs e)
        {
            messenger?.ShowMessage(new MyMessage() { Message = "Успех!", TypeMessage = TypeMessage.Success });
        }
        private async void Error(object sender, RoutedEventArgs e)
        {
            messenger?.ShowMessage(new MyMessage() { Message = "Что же делать?", TypeMessage = TypeMessage.Error });
        }
        private async void Warning(object sender, RoutedEventArgs e)
        {
            messenger?.ShowMessage(new MyMessage() { Message = "Предупреждение!", TypeMessage = TypeMessage.Warning });
        }


    }

    public class ConsoleMessenger : IMessenger
    {
        public List<int>? Items { get; set; }

        public ConsoleMessenger()
        {
            Items = Enumerable.Range(0, 10).Select(x => x).ToList();
        }

        public void ShowMessage(IMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
