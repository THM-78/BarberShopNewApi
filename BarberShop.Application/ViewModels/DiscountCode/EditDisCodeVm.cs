using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.DiscountCode
{
    public class EditDisCodeVm
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;

        public int DiscountPercent { get; set; }
    }
}
