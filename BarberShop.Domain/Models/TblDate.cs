using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblDate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReserveDate { get; set; }

    public bool IsReserved { get; set; }

    public int? ServiceId { get; set; }

    public int? HairStylistId { get; set; }

    [ForeignKey("HairStylistId")]
    [InverseProperty("TblDates")]
    public virtual TblHairStylist? HairStylist { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("TblDates")]
    public virtual TblService? Service { get; set; }

    [InverseProperty("Date")]
    public virtual ICollection<TblReservation> TblReservations { get; set; } = new List<TblReservation>();
}
