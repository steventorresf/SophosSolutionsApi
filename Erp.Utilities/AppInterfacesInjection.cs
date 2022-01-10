using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Utilities
{
    public static class AppInterfacesInjection
    {
        public static IServiceCollection AddInterfacesInjection(this IServiceCollection services)
        {
            #region Facades
            services.AddScoped<Facade.Interfaces.IClienteFacade, Facade.Implementations.ClienteFacade>();
            services.AddScoped<Facade.Interfaces.IProductoFacade, Facade.Implementations.ProductoFacade>();
            services.AddScoped<Facade.Interfaces.IVentaFacade, Facade.Implementations.VentaFacade>();
            #endregion

            #region Repositories
            services.AddScoped<Infrastructure.Interfaces.IClienteRepository, Infrastructure.Implementations.ClienteRepository>();
            services.AddScoped<Infrastructure.Interfaces.IProductoRepository, Infrastructure.Implementations.ProductoRepository>();
            services.AddScoped<Infrastructure.Interfaces.IVentaRepository, Infrastructure.Implementations.VentaRepository>();
            #endregion
            return services;
        }
    }
}
