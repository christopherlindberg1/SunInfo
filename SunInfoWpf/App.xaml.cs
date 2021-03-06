using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CoreLibrary;
using CoreLibrary.ApiClients;
using Microsoft.Extensions.DependencyInjection;

namespace SunInfoWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;


        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IApiHelper, ApiHelper>();
            services.AddSingleton<ISunApiClient, SunApiClient>();
            services.AddSingleton<ILatitudeValidator, LatitudeValidator>();
            services.AddSingleton<ILongitudeValidator, LongitudeValidator>();
            services.AddSingleton<IErrorMessageHandler, ErrorMessageHandler>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
