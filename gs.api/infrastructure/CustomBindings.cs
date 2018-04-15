using gs.api.contracts.reseller.services.interfaces;
using gs.api.contracts.reseller.services.interfaces.dicts;
using gs.api.converters;
using gs.api.converters.reseller;
using gs.api.infrastructure.logging;
using gs.api.infrastructure.settings;
using gs.api.services.reseller;
using gs.api.services.reseller.dicts;
using gs.api.storage;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using GoodCategory = gs.api.contracts.reseller.dto.dicts.goodCategories.GoodCategory;
using Good = gs.api.contracts.reseller.dto.dicts.goods.Good;

using GoodCategoryDb = gs.api.storage.model.resellers.dicts.GoodCategory;
using GoodDb = gs.api.storage.model.resellers.dicts.Good;

namespace gs.api.infrastructure
{
    /// <summary>
    /// DI container bindings.
    /// </summary>
    public static class CustomBindings
    {
        public static void Bind(IServiceCollection services, IConfiguration configuration)
        {
            BindMappers(services);
            BindSettings(services, configuration, out var appSettings);
            BindServices(services, configuration);
            BindDatabase(services, configuration, appSettings);

            services.AddScoped(_ => new CallContext());
            services.AddTransient<TelemetryClient>();

            services.AddTransient<ILog, ApplicationInsightsLogger>();
        }
        
        public static void Use(IApplicationBuilder app)
        {
            app.UseMiddleware<CorsMiddlewareStub>();
            app.UseMiddleware<SetContextMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }

        private static void BindServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IAuthService, AuthService>();
//            services.AddTransient<IGoodsService, GoodsService>();
            services.AddTransient<IStoresService, StoresService>();
            
            services.AddTransient<ICrudService<GoodCategory>, CrudService<GoodCategory, GoodCategoryDb>>();
            services.AddTransient<ICrudService<Good>, CrudService<Good, GoodDb>>();
        }

        private static void BindMappers(IServiceCollection services)
        {
            services.AddTransient<IEntityMapper<GoodCategory, GoodCategoryDb>, GoodCategoryMapper>();
            services.AddTransient<IEntityMapper<Good, GoodDb>, GoodMapper>();
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
        }
    }
}