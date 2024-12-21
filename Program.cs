using AmentumExploratory.Components;
using AmentumExploratory.Data;
using AmentumExploratory.Logic;
using Microsoft.EntityFrameworkCore;

namespace AmentumExploratory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services
                .AddDbContextFactory<ExploratoryDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"), c => c.EnableRetryOnFailure(10));
                });

            builder.Services.AddScoped<DataAccessService>();
            builder.Services.AddSingleton<ContextService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.UseContextMiddleware();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
