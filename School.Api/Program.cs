using Microsoft.AspNetCore.Mvc.Razor;
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

builder.Services.AddControllers().AddMvcOptions(opt =>
{
    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
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
       new CultureInfo("ar-EG")



   };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar-EG", uiCulture: "ar-EG");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});
builder.Services.AddMvc()
       .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
       .AddDataAnnotationsLocalization();

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
