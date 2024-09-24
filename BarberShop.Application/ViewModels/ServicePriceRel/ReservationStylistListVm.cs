using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.ServicePriceRel
{
    public class ReservationStylistListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int HairStylistId { get; set; }
        public ReservationStylistListVm()
        {
            
        }

        public ReservationStylistListVm(TblServicePriceRel servicePriceRel)
        {
            Id = servicePriceRel.Id;
            Name = servicePriceRel.HairStylist.Name;
            Price = servicePriceRel.Price.Value.ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = "," }) + " تومان";
            HairStylistId = (int)servicePriceRel.HairStylistId;
        }

    }
}
