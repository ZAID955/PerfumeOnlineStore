using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Core.Models.Context;
using PerfumeOnlineStore_Infra.ReposImplementation;
using PerfumeOnlineStore_Infra.ServiceImplementation;
using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", info: new OpenApiInfo
    {
        Version = "v1",
        Title = "Perfume Online Store",
        Description = "The Perfume Online Store API streamlines business management processes for product management, " +
        "orders, delivery, client interactions, and reviews. Easily add, update, and remove products," +
        " process orders, track deliveries, handle client interactions, and collect and manage reviews. With this API",
        TermsOfService = new Uri("https://github.com/ZAID955"),
        Contact = new OpenApiContact
        {
            Name = "Zaid Raed Hammouda",
            Email = "zaidhamouda2333@gmail.com",
            Url = new Uri("https://www.google.com")
        },
        License = new OpenApiLicense
        {
            Name = "My license",
            Url = new Uri("https://github.com/ZAID955")
        }
    });
});
builder.Services.AddDbContext<PerfumeOnlineStoreDbContext>(cop =>
cop.UseSqlServer(builder.Configuration.GetValue<string>(key: "sqlconnect")));

builder.Services.AddScoped<IAdmanServiceInterface, AdmanService>();
builder.Services.AddScoped<IAdmanReposInterface, AdmanRepos>();

builder.Services.AddScoped<IClientServiceInterface, ClientService>();
builder.Services.AddScoped<IClientReposInterface, ClientRepos>();


builder.Services.AddScoped<IDeliveryServiceInterface, DeliveryService>();
builder.Services.AddScoped<IDeliveryReposInterface, DeliveryRepos>();
builder.Services.AddScoped<ISharedServiceInterface, SharedService>();
builder.Services.AddScoped<ISharedReposInterface, SharedRepos>();

Log.Logger = new LoggerConfiguration()
      .WriteTo.File(new JsonFormatter(),
      @"C:\Users\Dell G15\Desktop\logs\logger.txt", 
      rollingInterval: RollingInterval.Minute)
      .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
