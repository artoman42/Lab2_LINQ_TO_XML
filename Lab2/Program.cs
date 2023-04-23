using LibraryBLL;
using LibraryDAL;
using LibraryUIL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent
            .Parent.FullName + "/LibraryDAL/appsettings")
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
            .Configure<MyConfiguration>(options => configuration.GetSection("MyConfiguration")
            .Bind(options))
            .AddServices()
            .BuildServiceProvider();
            serviceProvider.GetService<IRunner>().Run();
        }
    }
}