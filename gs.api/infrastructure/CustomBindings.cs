using gs.api.contracts.reseller.services.interfaces;
using gs.api.infrastructure.settings;
using gs.api.services.reseller;
using gs.api.storage;
using gs.api.storage.repositories;
using gs.api.storage.repositories.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gs.api.infrastructure
{
    /// <summary>
    /// DI container bindings.
    /// </summary>
    public static class CustomBindings
    {
        public static void Bind(IServiceCollection services, IConfiguration configuration)
        {
            BindSettings(services, configuration, out var appSettings);
            BindServices(services, configuration);
            BindDatabase(services, configuration, appSettings);
        }
        
        public static void Use(IApplicationBuilder app)
        {
            InitializeDabatase(app);
        }

        private static void BindServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IAuthService, AuthService>();
        }

        private static void BindSettings(IServiceCollection services, IConfiguration configuration, 
            out AppSettings appSettings)
        {
            appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            services.AddSingleton<IDbSettings>(appSettings);
        }

        private static void BindDatabase(IServiceCollection services, IConfiguration configuration,
            IDbSettings dbSettings)
        {
            services.
                AddEntityFrameworkNpgsql()
                .AddDbContext<Context>(options => options.UseNpgsql(dbSettings.ConnectionString));

            services.AddTransient<IOrganizationsRepository, OrganizationsRepository>();
        }
        
        private static void InitializeDabatase(IApplicationBuilder app)
        {
            
        }
    }
}