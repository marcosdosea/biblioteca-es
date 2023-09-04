using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Service;

namespace BibliotecaWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IAutorService, AutorService>();
            builder.Services.AddTransient<IEditoraService, EditoraService>();
            builder.Services.AddTransient<ILivroService, LivroService>();
            builder.Services.AddTransient<IItemAcervoService, ItemAcervoService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<BibliotecaContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("BibliotecaDatabase")));
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