using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.Middlewares;
using WebShop.Application.Services;
using WebShop.Domain.Entities;
using WebShop.Domain.Interfaces;
using WebShop.Infrastructure;
using WebShop.Infrastructure.Repositories;

namespace WebShop.WebApi
{
    public class Program
    {
        public static void Main (string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            builder.Services.AddScoped<IRepository<Category, Guid>, CategoryRepository>();
            builder.Services.AddScoped(typeof(BaseService<,,>));
            builder.Services.AddScoped<IFileService, FileService>();

            builder.Services.AddValidatorsFromAssembly(typeof(BaseService<,,>).Assembly);
            WebApplication app = builder.Build();
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
