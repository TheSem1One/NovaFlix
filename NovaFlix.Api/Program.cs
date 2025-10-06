using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovaFlix.Infrastructure.Options;
using NovaFlix.Infrastructure.Persistance;

namespace NovaFlix.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NovaFlix.API", Version = "v1" }));

            builder.Services.Configure<DatabaseConnection>(
                builder.Configuration.GetSection(DatabaseConnection.SectionName));

            builder.Services.AddDbContext<DatabaseContext>(opts =>
                opts.UseNpgsql(
                    builder.Configuration.GetConnectionString("ApiDatabase")
                )
            );

            builder.Services.AddControllers();

            builder.Services.AddCors(o => o.AddPolicy("AllowAny", corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

            builder.Services.AddOpenApi();


            var app = builder.Build();

 
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAny");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
