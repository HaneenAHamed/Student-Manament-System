using Microsoft.EntityFrameworkCore;

using Student_Managmet.Middleware;
using Student_Managmet.Data;

namespace Student_Managmet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDBContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
     
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseMiddleware<RequestLogsURLMaddleware>();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}")
                ;

            app.Run();
        }
    }
}
