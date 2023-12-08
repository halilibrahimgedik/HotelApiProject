using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.BusinessLayer.Concrete;
using MyHotel.DataAccessLayer.Abstract;
using MyHotel.DataAccessLayer.Concrete;
using MyHotel.DataAccessLayer.Concrete.EfCore;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.GuestDto;
using MyHotel.WebUI.ValidationRules.GuestValidationRules;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<Program>(); //!Toplu validator

builder.Services.AddDbContext<Context>(options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=MyHotelDb;Integrated Security=true;"));
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingRepository, EfCoreBookingRepository>();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(Program));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Index}/{id?}");

app.Run();
