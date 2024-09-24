using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.ServicePriceRel
{
    public class ServicePriceListVm
    {
        public int Id { get; set; }
        public string HairStylist { get; set; }

        public string Service { get; set; }

        public long Price { get; set; }
    }
}
