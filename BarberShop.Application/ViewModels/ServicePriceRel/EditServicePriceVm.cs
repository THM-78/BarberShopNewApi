using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.ServicePriceRel
{
    public class EditServicePriceVm
    {
        public int Id { get; set; }
        public int HairStylistId { get; set; }

        public int ServiceId { get; set; }

        public long Price { get; set; }
    }
}
