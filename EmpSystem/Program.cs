using EmpSystem.BL.Interface;
using EmpSystem.BL.Mapper;
using EmpSystem.BL.Repository;
using EmpSystem.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
builder.Services.AddScoped<ICityRep, CityRep>();
builder.Services.AddScoped<ICountryRep , CountryRep>();
builder.Services.AddScoped<IDistrictRep, DistrictRep>();
builder.Services.AddDbContextPool<DbContainer>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("SharpDBConnection")));
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
