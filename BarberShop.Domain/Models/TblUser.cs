using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(16)]
    public string FirstName { get; set; } = null!;

    [StringLength(16)]
    public string LastName { get; set; } = null!;

    [StringLength(16)]
    public string Tell { get; set; } = null!;

    [StringLength(256)]
    public string? Email { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<TblReservation> TblReservations { get; set; } = new List<TblReservation>();
}
