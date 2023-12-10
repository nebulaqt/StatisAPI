using System.Net.NetworkInformation;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/domainstatus/{domain}", async (string domain) => await CheckIfDomainOnline(domain))
    .WithName("GetDomainStatus")
    .WithOpenApi();

// Add this line to keep the application running.
await app.RunAsync();
return;

// This is the extracted method.
async Task<string> CheckIfDomainOnline(string domain)
{
    try
    {
        var ping = new Ping();
        var result = await ping.SendPingAsync(domain, 1000);
        await Task.Delay(1000); // delay was moved inside the extracted method.
        return result.Status == IPStatus.Success ? "Online" : "Offline";
    }
    catch (PingException)
    {
        return "Offline";
    }
    catch (ArgumentException)
    {
        return "Offline";
    }
    catch (InvalidOperationException)
    {
        return "Offline";
    }
    catch (SocketException)
    {
        return "Offline";
    }
    catch (Exception)
    {
        return "Error occurred while trying to ping domain";
    }
}