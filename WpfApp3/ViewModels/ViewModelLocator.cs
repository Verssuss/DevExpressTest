using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace WpfApp3.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModel ViewModel { get; set; } = Ioc.Default.GetService<ViewModel>();
        public static AuthorizeViewModel AuthorizeViewModel { get; set; } = Ioc.Default.GetService<AuthorizeViewModel>();
    }
}