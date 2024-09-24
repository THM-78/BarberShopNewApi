using AutoMapper;
using BarberShop.Application.ViewModels.BeforeAfterImg;
using BarberShop.Application.ViewModels.DiscountCode;
using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Application.ViewModels.HairStylistLevel;
using BarberShop.Application.ViewModels.Reservation;
using BarberShop.Application.ViewModels.Service;
using BarberShop.Application.ViewModels.ServicePriceRel;
using BarberShop.Application.ViewModels.Suggestion;
using BarberShop.Application.ViewModels.WorkPhoto;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Profiles
{
    public class MappiingProfile : Profile
    {
        public MappiingProfile()
        {
            #region Suggestions
            CreateMap<TblSuggestion, SuggestionVm>();
            CreateMap<CreateSuggestionVm, TblSuggestion>();
            #endregion
            #region Before After Images
            CreateMap<CreateBeforeAfterVm, TblBeforeAfter>();
            CreateMap<EditBeforeAfterVm, TblBeforeAfter>();
            CreateMap<TblBeforeAfter, BeforeAfterListVm>();
            CreateMap<TblBeforeAfter, BeforeAfterVm>();
            #endregion

            #region HairStylist
            CreateMap<CreateHairStylistVm, TblHairStylist>()
                .ForMember(dest => dest.HairStylistLevel, opt => opt.MapFrom(src => src.HairStylistLevel))
                .AfterMap((src, dest) => dest.HairStylistLevel.StylistLevel = src.HairStylistLevel);
            CreateMap<TblHairStylist, HairStylistVm>()
                .ForMember(dest => dest.HairStylistLevel, opt => opt.MapFrom(src => src.HairStylistLevel.StylistLevel));
            CreateMap<TblHairStylist, HairStylistListVm>()
                .ForMember(dest => dest.HairStylistLevel, opt => opt.MapFrom(src => src.HairStylistLevel.StylistLevel));
            CreateMap<EditHairStylistVm, TblHairStylist>();
            #endregion

            #region HairStylist Level
            CreateMap<CreateStylistLevelVm, TblHairStylistLevel>();
            CreateMap<TblHairStylistLevel, StylistLevelListVm>();
            CreateMap<EditStylistLevelVm, TblHairStylistLevel>();
            #endregion


            #region Service
            CreateMap<CreateServiceVm, TblService>();
            CreateMap<TblService, ServiceListVm>();
            CreateMap<TblService, ServiceVm>();
            CreateMap<EditServiceVm,  TblService>();    
            #endregion

            #region WorkPhoto
            CreateMap<CreateWorkPhotoVm, TblWorkPhoto>();
            CreateMap<TblWorkPhoto, WorkPhotoListVm>();
            CreateMap<TblWorkPhoto, WorkPhotoVm>();
            CreateMap<EditWorkPhotoVm, TblWorkPhoto>();
            #endregion

            #region Discount Code
            CreateMap<TblDiscountCode, DisCodeListVm>();
            CreateMap<TblDiscountCode, DisCodeVm>();
            CreateMap<EditDisCodeVm, TblDiscountCode>();
            CreateMap<CreateDisCodeVm, TblDiscountCode>();
            #endregion

            #region ServicePriceRel
            CreateMap<TblServicePriceRel, ReservationStylistListVm>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value.ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = "," }) + " تومان"))
                .ForMember(dest => dest.HairStylistId, opt => opt.MapFrom(src => src.HairStylistId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.HairStylist.Name));
            CreateMap<CreateServicePriceVm, TblServicePriceRel>();
            CreateMap<TblServicePriceRel, ServicePriceListVm>()
                .ForMember(dest => dest.HairStylist, opt => opt.MapFrom(src => src.HairStylist.Name))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service.Type));
            CreateMap<TblServicePriceRel, ServicePriceVm>()
                .ForMember(dest => dest.HairStylist, opt => opt.MapFrom(src => src.HairStylist.Name))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Service.Type));
            CreateMap<EditServicePriceVm, TblServicePriceRel>();
            //CreateMap<PriceVm, TblServicePriceRel>();
            #endregion

            #region Reservation
            CreateMap<CreateReservationVm, TblReservation>();
            CreateMap<TblReservation, ReservationVm>();
            CreateMap<TblReservation, ReservationListVm>();
            CreateMap<EditReservationVm, TblReservation>();
            CreateMap<TblReservation, ReservationTimeTableVm>()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.ReserveDate.ToString("HH:mm")));
            #endregion
        }
    }
}
