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

//app.UseHttpsRedirection();
app.MapGet("/domainstatus/{domain}", async (string domain) => 
{
    try
    {
        var ping = new Ping();
        var result = await ping.SendPingAsync(domain, 1000);
        return result.Status == IPStatus.Success ? "Online" : "Offline";
    }
    catch(Exception ex)
    {
        return ex is PingException or ArgumentException or InvalidOperationException or SocketException ? "Offline" : "Error occurred while trying to ping domain";
    }
	finally
	{
        // Set a delay here to prevent the app from terminating immediately.
        await Task.Delay(1000);
	}
})
.WithName("GetDomainStatus")
.WithOpenApi();

// Add this line to keep the application running.
await app.RunAsync();