using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

[Table("TblReservation")]
public partial class TblReservation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReserveDate { get; set; }

    public bool IsReserved { get; set; }

    public int? ServicePriceRelId { get; set; }

    public int? UserId { get; set; }

    [ForeignKey("ServicePriceRelId")]
    [InverseProperty("TblReservations")]
    public virtual TblServicePriceRel? ServicePriceRel { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("TblReservations")]
    public virtual TblUser? User { get; set; }
}
