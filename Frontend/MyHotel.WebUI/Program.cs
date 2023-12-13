using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Login"; 
    options.LogoutPath = "/account/logout"; 

    options.AccessDeniedPath = "/account/accessdenied";

    options.SlidingExpiration = true;     // ?varsay�lan cookie s�resi 20 dk d�r. Her istek de bu s�re s�f�rlan�r.(false dersek 20 dk i�inde istek yapsanda yapmasanda 20 dk dolarsa seni login olmaya y�nlendirecek) 

    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //? varsay�lan cookie nin s�resini 60dk olarak ayarlar.Varsay�lan olarak 20 idi normalde, biz de�i�tirdik

    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,    // ? cookie sadece http talebi ile elde edilebilir. scriptler elde edemesin
        Name = ".TechcareerFinalTask.Security.Coookie"      // ? Taray�c�da g�z�ken Cookie name'ini �zelle�tirme
    };

});

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

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}"); // ? hata almam�z durumunda gidilecek sayfay� tan�mlad�k - 404 error sayfas�
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Index}/{id?}");

app.Run();
