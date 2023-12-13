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

    options.SlidingExpiration = true;     // ?varsayýlan cookie süresi 20 dk dýr. Her istek de bu süre sýfýrlanýr.(false dersek 20 dk içinde istek yapsanda yapmasanda 20 dk dolarsa seni login olmaya yönlendirecek) 

    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //? varsayýlan cookie nin süresini 60dk olarak ayarlar.Varsayýlan olarak 20 idi normalde, biz deðiþtirdik

    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,    // ? cookie sadece http talebi ile elde edilebilir. scriptler elde edemesin
        Name = ".TechcareerFinalTask.Security.Coookie"      // ? Tarayýcýda gözüken Cookie name'ini özelleþtirme
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

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}"); // ? hata almamýz durumunda gidilecek sayfayý tanýmladýk - 404 error sayfasý
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Index}/{id?}");

app.Run();
