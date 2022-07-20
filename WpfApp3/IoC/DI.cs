using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using WpfApp3.Encrypting;
using WpfApp3.Models;
using WpfApp3.Repositories;
using WpfApp3.ViewModels;

namespace WpfApp3.IoC
{
    internal class DI
    {
        public DI()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICrypted, RfcCrypt>();
            services.AddSingleton<IDataStore<Employee>, JsonDataStore>();
            services.AddSingleton<ViewModel>();
            services.AddSingleton<AuthorizeViewModel>();

            var serviceProvider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(serviceProvider);
        }

        public static IDataStore<Employee> Data { get; set; } = Ioc.Default.GetService<IDataStore<Employee>>();
    }
}