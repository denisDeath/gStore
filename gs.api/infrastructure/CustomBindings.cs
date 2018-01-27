using gs.api.infrastructure.settings;
using gs.api.services.suppliers;
using gs.api.services.suppliers.interfaces;
using gs.api.storage.repositories.interfaces;
using gs.api.storage.repositories.sqlServer;
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
            BindSettings(services, configuration);
            BindServices(services, configuration);
            BindDatabase(services, configuration);
        }

        private static void BindServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IGoodsService, GoodsService>();
        }

        private static void BindDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<Context>();
            services.AddTransient<ISupplierGoodsRepository, SupplierGoodsRepository>();
        }

        private static void BindSettings(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            services.AddSingleton<IDbSettings>(appSettings);
        }
    }
}