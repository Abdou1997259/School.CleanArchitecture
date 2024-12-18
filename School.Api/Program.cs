using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School.Core;
using School.Handlers.Extension;
using School.Infrastructure;
using School.Infrastructure.Context;
using School.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCoreDependencies();
builder.Services.AddServiceDependencies();
builder.Services.AddInfrastructureDependencies();
builder.Services.AddHandlersDependencies();
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> cultures = new List<CultureInfo>
   {
       new CultureInfo("en-US"),
       new CultureInfo("ar_EG")



   };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cultures[1]);
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseHttpsRedirection();
app.AddMiddleWares();
app.UseAuthorization();

app.MapControllers();

app.Run();
