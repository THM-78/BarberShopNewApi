using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblBarbershopInfo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(256)]
    public string Address { get; set; } = null!;

    [StringLength(16)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(128)]
    public string InstaPage { get; set; } = null!;
}
