using ClinicService.Data;
using ClinicService2.Services.Impl;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net;

namespace ClinicService2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Kastrel

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 5001, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });
                options.Listen(IPAddress.Any, 5101, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1;
                });
            });
            #endregion

            #region Configure gRPC
            
            builder.Services
                .AddGrpc()
                .AddJsonTranscoding();

            #endregion

            #region Configure Db
            builder.Services.AddDbContext<ClinicServiceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["Settings:DatabaseOptions:ConnectionString"]);
            });
            #endregion

            #region Configure Swagger

            //usefull link https://learn.microsoft.com/ru-ru/aspnet/core/grpc/json-transcoding-openapi?view=aspnetcore-7.0
            builder.Services.AddGrpcSwagger();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "ClinicService2", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "ClinicService2.xml");
                c.IncludeXmlComments(filePath);
                c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
            });

            #endregion

            builder.Services.AddAuthorization();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicService2 V1");
                });
            }
            // Configure the HTTP request pipeline.
            app.UseRouting();
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true});            
            app.MapGrpcService<ClinicClientService>().EnableGrpcWeb();
            app.MapGet("/",
                ()=>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}