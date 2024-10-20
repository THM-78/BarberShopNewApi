using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.Reservation
{
    public class SearchByDateResult
    {
        public int  FromYear { get; set; }
        public int FromMonth { get; set; }
        public int FromDay { get; set; }
        public int UntilYear { get; set; }
        public int UntilMonth { get; set; }
        public int UntilDay { get; set; }
    }
}
