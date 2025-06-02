using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
var builder = WebApplication.CreateBuilder(args);

//////// Add services to the container.
////////var cert = new X509Certificate2("/home/user/certs/server.crt", "/home/user/certs/server.key");

var cert = new X509Certificate2("/etc/ssl/private/SimonERP_Hana.pfx", "");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(2222, listenOptions =>
    {
        listenOptions.UseHttps(cert);
    });
});

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.Use(async (context, next) =>
{
    logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    logger.LogInformation($"Response: {context.Response.StatusCode}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("", () => Results.Ok(new { status = "API is running" }));
app.Run();
