using GarageApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GarageApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Registration of user services in DI container
            var builder = WebApplication.CreateBuilder(args);
            string? connectionString = builder.Configuration
                .GetConnectionString("DevConnection");

            builder.Services.AddDbContext<GarageAppDbContext>(opt =>
            {
                //Here we configure the DbContext the same way as in "OnConfiguring()" method
                opt.UseSqlServer(connectionString);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Application configuration
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();// CSS/JS/IMG
            //app.MapStaticAssets();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //.WithStaticAssets();

            app.Run();
        }
    }
}