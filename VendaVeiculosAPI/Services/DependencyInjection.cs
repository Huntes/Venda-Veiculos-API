using VendaVeiculosAPI.Services.Impl;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IArquivoService, ArquivoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioArquivoService, UsuarioArquivoService>();
            services.AddScoped<ICarroArquivoService, CarroArquivoService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
