using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblService
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Type { get; set; } = null!;

    public int? PeriodOfTime { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<TblServicePriceRel> TblServicePriceRels { get; set; } = new List<TblServicePriceRel>();
}
