using VendaVeiculosAPI.Repositories.Impl;
using VendaVeiculosAPI.Repositories.Interfaces;

namespace VendaVeiculosAPI.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioArquivoRepository, UsuarioArquivoRepository>();
            services.AddScoped<ICarroArquivoRepository, CarroArquivoRepository>();

            return services;
        }
    }
}
