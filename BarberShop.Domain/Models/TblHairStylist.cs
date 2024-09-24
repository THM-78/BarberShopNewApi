using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblHairStylist
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    [StringLength(64)]
    public string ImageUrl { get; set; } = null!;

    public int? HairStylistLevelId { get; set; }

    [ForeignKey("HairStylistLevelId")]
    [InverseProperty("TblHairStylists")]
    public virtual TblHairStylistLevel? HairStylistLevel { get; set; }

    [InverseProperty("HairStylist")]
    public virtual ICollection<TblServicePriceRel> TblServicePriceRels { get; set; } = new List<TblServicePriceRel>();
}
