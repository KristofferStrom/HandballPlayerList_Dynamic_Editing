using HandballPlayers_DynamicList.Console.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
           .ConfigureServices(services =>
           {
               services.AddLogging(builder =>
               {
                   builder.AddConsole().SetMinimumLevel(LogLevel.None);
               });

               services.AddScoped<HandballPlayersService>();
               services.AddScoped<ConsoleService>();
               services.AddScoped<UserInterfaceService>();
               services.AddSingleton<TableColorService>();
               services.AddSingleton<HandballPlayerTableService>();

           })
           .Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;


    var menuService = services.GetRequiredService<UserInterfaceService>();
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    menuService.MainPage();
}

await host.RunAsync();