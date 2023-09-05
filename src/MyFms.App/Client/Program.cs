using Majorsoft.Blazor.Components.Common.JsInterop;
using Majorsoft.Blazor.Components.Maps;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFms.Application.Services;
using MyFms.Infrastructure.Services;

namespace MyFms.App;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services
            .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
            .AddJsInteropExtensions()
            .AddMapExtensions()
            .AddSingleton<IMyFmsClient, MyFmsClient>()
            .AddSingleton<EventMapService>()
            .AddSingleton<IMapService>(provider => provider.GetRequiredService<EventMapService>());
        

		await builder.Build().RunAsync();
    }
}