using Microsoft.EntityFrameworkCore;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.BusinessLayer.Concrete;
using MyHotel.DataAccessLayer.Abstract;
using MyHotel.DataAccessLayer.Concrete;
using MyHotel.DataAccessLayer.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")));

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingRepository, EfCoreBookingRepository>();

builder.Services.AddScoped<IStaffService,StaffManager>();
builder.Services.AddScoped<IStaffRepository,EfCoreStaffRepository>();

builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceRepository, EfCoreServiceRepository>();

builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<IRoomRepository, EfCoreRoomRepository>();

builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ISubscribeRepository, EfCoreSubscribeRepository>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialRepository, EfCoreTestimonialRepository>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutRepository, EfCoreAboutRepository>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactRepository, EfCoreContactRepository>();

builder.Services.AddScoped<IGuestService, GuestManager>();
builder.Services.AddScoped<IGuestRepository, EfCoreGuestRepository>();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
