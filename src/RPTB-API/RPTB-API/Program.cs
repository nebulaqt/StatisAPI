using System.Net.NetworkInformation;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);
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
    
await app.RunAsync();
return;

async Task<string> CheckIfDomainOnline(string domain)
{
    try
    {
        var ping = new Ping();
        var result = await ping.SendPingAsync(domain, 1000);
        return result.Status == IPStatus.Success ? "Online" : "Offline";
    }
    catch (Exception ex)
    {
        return HandleExceptions(ex);
    }
}

string HandleExceptions(Exception ex)
{
    return ex is PingException or ArgumentException or InvalidOperationException or SocketException ? "Offline" : "Error occurred while trying to ping domain";
}