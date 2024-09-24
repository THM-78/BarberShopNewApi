using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.Reservation
{
    public class EditReservationVm
    {
        public int Id { get; set; }
        public DateTime ReserveDate { get; set; }

        public bool IsReserved { get; set; }

        public int? ServicePriceRelId { get; set; }

        public int? UserId { get; set; }
    }
}
