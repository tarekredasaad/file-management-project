
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DynamicAuthApi.Middlewaare;
//using DynamicAuthApi.AuthorizationRequirement;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;

namespace DynamicAuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x =>
               x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("myPolicy", op => op.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            // Add services to the container.
            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

            });
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<Context>().AddSignInManager<SignInManager<ApplicationUser>>();
            //;
            builder.Services.AddTransient< UnAuthorized>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            //builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IDocumentServicce, DocumentServices>();
            //builder.Services.AddScoped<IAuthorizationHandler, GroupPermissionAuthorizationHandler>();

            //builder.Services.AddAuthorization(options =>
            //{
            //    //options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
            //    //options.AddPolicy("deleteUser", policy => policy.RequireRole("Admin"));
            //    ////options.AddPolicy("AddProduct", policy => policy.RequireRole("Admin" ,"HRM"));
            //    //options.AddPolicy("getuser", policy => {
            //    //    policy.RequireRole("HRM", "Admin");
            //    //}) ;


            //    // You can add more policies as needed.
            //});
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<UnAuthorized>();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("myPolicy");
            //app.UseAuthorization();
            app.UseAuthentication();

            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}