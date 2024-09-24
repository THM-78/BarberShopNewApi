using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.Service
{
    public class ServiceVm
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? PeriodOfTime { get; set; }
    }
}
