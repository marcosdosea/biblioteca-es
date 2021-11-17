using AutoMapper;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;
using System.Globalization;

namespace BibliotecaWeb
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			
			// injeção dependência DBContext			
			services.AddDbContext<BibliotecaContext>(options =>
				options.UseMySQL(
					Configuration.GetConnectionString("BibliotecaConnection")));
			
			// injeção dependência Services
			services.AddTransient<IAutorService, AutorService>();
			services.AddTransient<IEditoraService, EditoraService>();
			services.AddTransient<ILivroService, LivroService>();
			services.AddTransient<IItemAcervoService, ItemAcervoService>();

			// injeção dependência mappers
			services.AddAutoMapper(typeof(Startup).Assembly);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();


			var suppportedCultures = new[] { new CultureInfo(name: "pt-BR") };
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
				SupportedCultures = suppportedCultures,
				SupportedUICultures = suppportedCultures
			}); ;

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
