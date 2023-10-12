using GroceryLine;
using GroceryLine.Models;
using GroceryLine.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var randomService = new RandomService();
List<Line> lines = randomService.GetRandomLines();

builder.Services.AddSingleton(ls => new LinesService(lines, randomService));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


