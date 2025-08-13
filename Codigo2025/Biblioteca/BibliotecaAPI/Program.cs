
using BibliotecaAPI.Filter;
using Core;
using Core.Identity.Data;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Service;

namespace BibliotecaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container with Exception handling.
            builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddTransient<IAutorService, AutorService>();
            builder.Services.AddTransient<ILivroService, LivroService>();
            
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<BibliotecaContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("BibliotecaDatabase")));

            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDatabase")));

            builder.Services.AddIdentityApiEndpoints<UsuarioIdentity>(
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


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

         
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapIdentityApi<UsuarioIdentity>();


            app.MapControllers();

            app.Run();
        }
    }
}
