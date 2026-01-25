using BookShelf.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string? connectionString = builder.Configuration
<<<<<<< HEAD:CSharpWeb-BookShelf-Jan2026/BookShelf/Program.cs
                .GetConnectionString("SqlServerDevConnection");
            builder.Configuration.GetValue<bool>("MyCustomSetting");
=======
                .GetConnectionString("DevConnection");

            builder.Services.AddDbContext<GarageAppDbContext>(opt =>
            {
                //Here we configure the DbContext the same way as in "OnConfiguring()" method
                opt.UseSqlServer(connectionString);
            });
>>>>>>> 78b2418cb5d941cdd55ba6d58961a797ce9e6e00:CSharpWeb-GarageApp-Jan2026/GarageApp/Program.cs

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BookShelfDbContext>(options =>
            {
                options
                    .UseSqlServer(connectionString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
<<<<<<< HEAD:CSharpWeb-BookShelf-Jan2026/BookShelf/Program.cs
=======
            app.UseStaticFiles();// CSS/JS/IMG
            //app.MapStaticAssets();

>>>>>>> 78b2418cb5d941cdd55ba6d58961a797ce9e6e00:CSharpWeb-GarageApp-Jan2026/GarageApp/Program.cs
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //.WithStaticAssets();

            app.Run();
        }
    }
}