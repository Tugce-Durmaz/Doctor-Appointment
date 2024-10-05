//using Doctor_Appointment.Data;
//using Microsoft.AspNetCore.Hosting.Server;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Doctor_Appointment.Service;
//using Doctor_Appointment.Service.Abstract;
//using Doctor_Appointment.Models;
//using Doctor_Appointment.Repositories;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllersWithViews();


//builder.Services.AddScoped<IPatientService, PatientService>();
//builder.Services.AddScoped<IDoctorService, DoctorService>();
//builder.Services.AddScoped<IPoliclinicService, PoliclinicService>();
//builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//builder.Services.AddScoped<IRepository<Patient>,Repository<Patient>>();
//builder.Services.AddScoped<IRepository<Doctor>,Repository<Doctor>> ();
//builder.Services.AddScoped<IRepository<Policlinic>, Repository<Policlinic>>();
//builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//var app = builder.Build();

//app.UseRouting();
//app.UseAuthorization();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Login}/{id?}");

//app.Run();


using Doctor_Appointment.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Doctor_Appointment.Service;
using Doctor_Appointment.Service.Abstract;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Servisleri konteynerimize ekleyelim.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPoliclinicService, PoliclinicService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
builder.Services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();
builder.Services.AddScoped<IRepository<Policlinic>, Repository<Policlinic>>();
builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Loglama yapılandırması
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Farklı loglama sağlayıcıları ekleyebilirsiniz

var app = builder.Build();

// Hata yakalama ara yazılımı
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "İstek işlenirken bir hata oluştu.");
        context.Response.StatusCode = 500; // İç Hata
        await context.Response.WriteAsync("İsteğinizi işleme alırken bir hata oluştu.");
    }
});

// HTTP istek hattının yapılandırılması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Bu yolu yöneten bir kontrolör ve görünüm olduğundan emin olun
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
