using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Plc.Data.Abstract;
using Plc.Data.Concrete;
using Plc.Data.Concrete.EntityFrameWork.Contexts;
using Plc.Entities.Concrete;
using Plc.Services.Abstract;
using Plc.Services.Concrete;

namespace Plc.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PlcContext>();
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;//şifre rakam içermek zorunda değil
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;//özel karakter sayısı
                options.Password.RequireNonAlphanumeric = false;//özel karakter gerek yok
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<PlcContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAreaService, AreaManager>();
            serviceCollection.AddScoped<IWorkCenterService, WorkCenterManager>();
            serviceCollection.AddScoped<IPlcService,PlcManager>();
            serviceCollection.AddScoped<IPlcTagService,PlcTagManager>();


            return serviceCollection;
        }
    }
}
