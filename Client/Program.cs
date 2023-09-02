using BlazorPro.BlazorSize;
using Majorsoft.Blazor.Components.Common.JsInterop;
using Majorsoft.Blazor.Components.Maps;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MyFms;

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
			.AddScoped<IResizeListener, ResizeListener>();

		await builder.Build().RunAsync();
    }
}