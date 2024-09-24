using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblHairStylistLevel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string StylistLevel { get; set; } = null!;

    [InverseProperty("HairStylistLevel")]
    public virtual ICollection<TblHairStylist> TblHairStylists { get; set; } = new List<TblHairStylist>();
}
