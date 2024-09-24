using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

[Table("TblDiscountCode")]
public partial class TblDiscountCode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Code { get; set; } = null!;

    public int DiscountPercent { get; set; }
}
