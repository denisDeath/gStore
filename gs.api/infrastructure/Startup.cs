using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using gs.api.auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace gs.api.infrastructure
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
 
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
 
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
            
            services.AddMvcCore()
                .AddJsonFormatters(x => x.Initialize());
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new Info { Title = "Evotor API", Version = "v1" });
//                
//                // list of tuples fileName - file extension.
//                var files = new List<Tuple<string, string>>();
//
//                files.AddRange(Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
//                    .Select(f => new Tuple<string, string>(f, "dll")));
//
//                foreach (Tuple<string, string> file in files)
//                {
//                    string commentFileName = file.Item1.Replace("." + file.Item2, ".xml");
//                    if (!File.Exists(commentFileName))
//                        continue;
//
//                    c.IncludeXmlComments(commentFileName);
//                }
//            });
            
            CustomBindings.Bind(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            CustomBindings.Use(app);
            app.UseMvc();
            
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Evotor API V1");
//            });
        }
    }
}