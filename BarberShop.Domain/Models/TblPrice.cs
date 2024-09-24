using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

[Table("TblPrice")]
public partial class TblPrice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal Price { get; set; }
}
