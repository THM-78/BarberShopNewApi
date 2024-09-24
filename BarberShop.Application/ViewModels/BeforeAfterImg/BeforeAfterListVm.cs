using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.BeforeAfterImg
{
    public class BeforeAfterListVm
    {
        public int Id { get; set; }
        public string? BeforeImgUrl { get; set; }
        public string? AfterImgUrl { get; set; }
    }
}
