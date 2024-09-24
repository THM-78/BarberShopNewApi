using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblServicePriceRel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int? HairStylistId { get; set; }

    public int? ServiceId { get; set; }

    public long? Price { get; set; }

    [ForeignKey("HairStylistId")]
    [InverseProperty("TblServicePriceRels")]
    public virtual TblHairStylist? HairStylist { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("TblServicePriceRels")]
    public virtual TblService? Service { get; set; }

    [InverseProperty("ServicePriceRel")]
    public virtual ICollection<TblReservation> TblReservations { get; set; } = new List<TblReservation>();
}
