﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.DiscountCode
{
    public class DisCodeVm
    {

        public string Code { get; set; } = null!;
        public int DiscountPercent { get; set; }
    }
}
