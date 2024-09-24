using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.BeforeAfterImg
{
    public class EditBeforeAfterVm
    {
        public int Id { get; set; }
        public string? BeforeImgUrl { get; set; }
        public string? AfterImgUrl { get; set; }
    }
}
