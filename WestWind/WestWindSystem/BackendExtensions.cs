using Microsoft.EntityFrameworkCore;  // for DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection; // for IServiceCollection, Action
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.BLL;


namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void BackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestWindContext>(options);

            services.AddTransient<CategoryServices>((ServiceProvider) =>
            {
                var dbContext = ServiceProvider.GetService<WestWindContext>();
                return new CategoryServices (dbContext);
            });

            services.AddTransient<ProductServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new ProductServices(dbContext);
            });

            
        }
    }
}
