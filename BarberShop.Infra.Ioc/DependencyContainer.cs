using BarberShop.Application.Interfaces;
using BarberShop.Application.Services;
using BarberShop.Domain.Interfaces;
using BarberShop.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Layer
            services.AddScoped<IBeforeAfterRepository, BeforeAfterRepository>();
            services.AddScoped<IDiscountCodeRepository,DiscountCodeRepository>();
            services.AddScoped<IinfoRepository, InfoRepository>();
            services.AddScoped<IServicePriceRelRepository, ServicePriceRelRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IStylistLevelRepository, StylistLevelRepository>();
            services.AddScoped<IStylistRepository, StylistRepository>();
            services.AddScoped<ISuggestionRepostory, SuggestionRepository>();
            services.AddScoped<IWorkPhotoRepository, WorkPhotoRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            //Application Layer
            services.AddScoped<IBeforeAfterService, BeforeAfterService>();
            services.AddScoped<IDiscountCodeService, DiscountCodeService>();
            services.AddScoped<IinfoService, BarberShopInfoService>();
            services.AddScoped<IServicePriceRelService, ServicePriceRelService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IStylistLevelService, StylistLevelService>();
            services.AddScoped<IStylistService, StylistService>();
            services.AddScoped<ISuggestionService, SuggestionService>();
            services.AddScoped<IWorkPhotoService, WorkPhotoService>();
            services.AddScoped<IReservationService, ReservationService>();

        }
    }
}
