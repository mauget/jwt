using System;
using System.IO;
using System.Reflection;
using JwtApi.Services;
using JwtApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace JwtApi
{
    public class Startup
    {
        private static readonly string _description =
            @"JSON Web Token API demonstration
            <ul>
                <li>GETs a payload from a signed base64-url-encoded JWt string</li>
                <li>POSTs a payload to a signed base64-url-encoded JWt string</li>
                <li>Any signature mismatch or a malformed input yields HTTP 406 'not acceptable' status</li>
            </ul>
            ";

        // This method is called by the runtime. Use this method to add to services container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IJwtService, JwtService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "JWT API",
                    Description = _description,
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. Perhaps change this for production scenarios. see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            // Set the URL and the contents of the version dropdown
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JSON Web Token API demonstration"));
        }
    }
}