using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var cert = new X509Certificate2("/home/user/certs/server.crt", "/home/user/certs/server.key");

var cert = new X509Certificate2("/etc/ssl/private/SimonERP_Hana.pfx", "");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1",
//        new Microsoft.OpenApi.Models.OpenApiInfo
//        {
//            Title = "FlutterApi.Api",
//            Description = "No description",
//            Contact = new Microsoft.OpenApi.Models.OpenApiContact
//            {
//                Name = "admin",
//                Email = "admin@ftiglobal.com.vn",
//                Url = new Uri("https://ftiglobal.com.vn/")
//            },
//            License = new Microsoft.OpenApi.Models.OpenApiLicense
//            {
//                Name = "MIT License",
//                Url = new Uri("https://opensource.org/licenses/MIT")
//            },
//            Version = "v1"
//        });

//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

//    c.IncludeXmlComments(xmlPath);

//    c.CustomOperationIds(apiDescription =>
//    {
//        return apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
//    });

//});



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
app.MapGet("/health", () => Results.Ok("API is running"));
app.Run();
