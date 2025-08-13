using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;
using Core.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;
using BibliotecaWeb.Helpers;
using BibliotecaWeb.Filter;

namespace BibliotecaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            }) ;
            builder.Services.AddTransient<IAutorService, AutorService>();
            builder.Services.AddTransient <IEditoraService, EditoraService> ();
            builder.Services.AddTransient<ILivroService, LivroService>();
            builder.Services.AddTransient<IItemAcervoService, ItemAcervoService>();

            // configuração do envio de emails para o usuário
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            

            builder.Services.AddDbContext<BibliotecaContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("BibliotecaDatabase")));

            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDatabase")));

            builder.Services.AddDefaultIdentity<UsuarioIdentity>(
                options =>
                {
                    // SignIn settings
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;

                    // Default User settings.
                    options.User.AllowedUserNameCharacters =
                            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    //options.User.RequireUniqueEmail = true;

                    // Default Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;
                }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            //Configure tokens life
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                //sets a 2 hour lifetime of the generated token to reset password/email/phone number
                options.TokenLifespan = TimeSpan.FromHours(2)
            );

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Autenticar";
                options.Cookie.Name = "BibliotecaCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Identity/Autenticar";
                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
