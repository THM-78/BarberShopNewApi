using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.ServicePriceRel
{
    public class ServicePriceVm
    {
        public int Id { get; set; }
        public int HairStylistId { get; set; }

        public int ServiceId { get; set; }
        public string HairStylist { get; set; } = null!;

        public string ServiceType { get; set; } = null!;
        public long Price { get; set; }
    }
}
