using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity.FrameworkCore;
using TaskNote.Entity.FrameworkCore.InMemory;
using TaskNote.Entity.FrameworkCore.SqlServer;
using TaskNote.Entity.Mapper;
using TaskNote.Entity.Sessions;

namespace TaskNote.WebApi
{
    public class Startup
    {
        private readonly string _allowSpecificOrigins = "allowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeOptions, DateTimeOptions>();

            services
                .AddTaskNoteDbContext<InMemoryContext>().AddDammyDbContext()
                .AddControllers();

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<AutoMapperProfileConfiguration>();
            }).AddSingleton<IMapper, Mapper>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _allowSpecificOrigins,
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskNote.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskNote.WebApi v1");
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                    });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_allowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
