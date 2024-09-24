using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.HairStylist
{
    public class HairStylistVm
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string HairStylistLevel { get; set; }
    }
}
