//using WinFormsCore.Views;
//using WinFormsCore.Services;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//namespace WinFormsCore
//{
//    static class Program
//    {
//        public static IServiceProvider ServiceProvider { get; private set; } = null;
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfiguration configuration = builder.Build();

//            var services = new ServiceCollection();

//            ServiceProvider = services.BuildServiceProvider();

//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

//            // Configure services
//            var serviceProvider = ServiceConfigurator.ConfigureServices(services, configuration);

//            // Resolve the MainForm with DI
//            var mainForm = serviceProvider.GetRequiredService<MainForm>();

//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            Application.Run(mainForm);
//        }
//    }
//}

using WinFormsCore.Views;
using WinFormsCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WinFormsCore.Models.Entities;

namespace WinFormsCore
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize the application settings, including HighDpiMode and compatible text rendering defaults.
            ApplicationConfiguration.Initialize();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();

            // Configure services with DI
            var serviceProvider = ServiceConfigurator.ConfigureServices(services, configuration);

            // Resolve the MainForm using DI
            var mainForm = serviceProvider.GetRequiredService<Customers>();

            // Start the application
            Application.Run(new Login());
            //Application.Run(mainForm);
        }
    }
}
