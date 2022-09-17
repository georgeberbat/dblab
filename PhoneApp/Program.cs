using Microsoft.AspNetCore;

namespace PhoneApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            // CreateHostBuilder(args).RunConsoleAsync().GetAwaiter().GetResult();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Startup>();
                });
            return builder;
        }

        public static IWebHost BuildWebHost(string[] args) =>

            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
