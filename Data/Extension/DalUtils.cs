using Data.DAL;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProiectFastTrack.Extension
{
    public class DalUtils
    {
        public static void AddDataAccessLayer(this IServiceCollection services, string? connString)
        {
            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connString));

            //services.AddScoped<IDataAccesLayerService, DataAccesLayerService>();
        }
    }
}
