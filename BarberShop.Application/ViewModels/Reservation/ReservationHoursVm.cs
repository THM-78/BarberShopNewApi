using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.Reservation
{
    public class ReservationHoursVm
    {
        public string Date { get; set; }
        public int IntervalTime { get; set; }
        public int ServiceId { get; set; }
        public string HairStylist { get; set; }
    }
}
