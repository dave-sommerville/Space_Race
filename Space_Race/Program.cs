using Microsoft.EntityFrameworkCore;
using Space_Race.DAL;
using Space_Race.BLL;

namespace Space_Race
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add services to the container.
            builder.Services.AddRazorPages();

            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<SpRaceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<DriverRepository>();
            builder.Services.AddScoped<DriverService>();
            builder.Services.AddScoped<VehicleRepository>();
            builder.Services.AddScoped<VehicleService>();
            builder.Services.AddScoped<TournamentRepository>();
            builder.Services.AddScoped<TournamentService>();
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
        }
    }
}
