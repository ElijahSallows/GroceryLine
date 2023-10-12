using GroceryLine;
using GroceryLine.Models;
using GroceryLine.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(ls => new LinesService(GetRandomDefaultLines()));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

List<Line> GetRandomDefaultLines()
{
    List<Line> lines = new();

    int linesCount = Faker.RandomNumber.Next(3, 7);
    for (int iLine = 0; iLine < linesCount; iLine++)
    {
        List<Customer> customers = new();

        int customerCount = Faker.RandomNumber.Next(0, 10);
        for (int iCustomer = 0; iCustomer < customerCount; iCustomer++)
        {
            int customerItemCount = Faker.RandomNumber.Next(1, 50);
            customers.Add(new Customer(customerItemCount));
        }
        lines.Add(new Line(customers));
    }

    return lines;
}
