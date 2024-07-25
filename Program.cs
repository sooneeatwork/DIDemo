using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DIDemo.Logging;
using DIDemo.Services;
using DIDemo.Configuration;

namespace DIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Without Dependency Injection:");
            RunWithoutDI();

            Console.WriteLine("\nWith Dependency Injection (Console Logger):");
            RunWithDI<ConsoleLogger>();

            Console.WriteLine("\nWith Dependency Injection (File Logger):");
            RunWithDI<FileLogger>();

            Console.WriteLine("\nDemonstrating Lifetimes:");
            DemonstrateLifetimes();
        }

        static void RunWithoutDI()
        {
            var userService = new UserServiceWithoutDI();
            userService.RegisterUser("john@example.com");

            var orderService = new OrderServiceWithoutDI();
            orderService.PlaceOrder("john@example.com", "PROD-001");

            // To change logger type or configuration, we need to modify both UserServiceWithoutDI and OrderServiceWithoutDI
        }

        static void RunWithDI<T>() where T : class, ILogger
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton(new LoggerConfiguration { MinimumLogLevel = LogLevel.Debug });
                    services.AddSingleton(new EmailConfiguration());
                    services.AddTransient<ILogger, T>();
                    services.AddTransient<IEmailService, EmailService>();
                    services.AddTransient<IUserService, UserService>();
                    services.AddTransient<IOrderService, OrderService>();
                })
                .Build();

            var userService = host.Services.GetRequiredService<IUserService>();
            userService.RegisterUser("jane@example.com");

            var orderService = host.Services.GetRequiredService<IOrderService>();
            orderService.PlaceOrder("jane@example.com", "PROD-002");
        }

        static void DemonstrateLifetimes()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton(new LoggerConfiguration { MinimumLogLevel = LogLevel.Debug });
                    services.AddTransient<ILogger, FileLogger>();
                    services.AddTransient<ITransientLifetimeDemoService, TransientLifetimeDemoService>();
                    services.AddScoped<IScopedLifetimeDemoService, ScopedLifetimeDemoService>();
                    services.AddSingleton<ISingletonLifetimeDemoService, SingletonLifetimeDemoService>();
                })
                .Build();

            using (var scope1 = host.Services.CreateScope())
            {
                Console.WriteLine("Scope 1:");
                ShowLifetimeDemos(scope1.ServiceProvider);
            }

            using (var scope2 = host.Services.CreateScope())
            {
                Console.WriteLine("\nScope 2:");
                ShowLifetimeDemos(scope2.ServiceProvider);
            }
        }

        static void ShowLifetimeDemos(IServiceProvider services)
        {
            Console.WriteLine("Transient:");
            var transient1 = services.GetRequiredService<ITransientLifetimeDemoService>();
            var transient2 = services.GetRequiredService<ITransientLifetimeDemoService>();
            transient1.LogId();
            transient2.LogId();

            Console.WriteLine("\nScoped:");
            var scoped1 = services.GetRequiredService<IScopedLifetimeDemoService>();
            var scoped2 = services.GetRequiredService<IScopedLifetimeDemoService>();
            scoped1.LogId();
            scoped2.LogId();

            Console.WriteLine("\nSingleton:");
            var singleton1 = services.GetRequiredService<ISingletonLifetimeDemoService>();
            var singleton2 = services.GetRequiredService<ISingletonLifetimeDemoService>();
            singleton1.LogId();
            singleton2.LogId();
        }
    }
}