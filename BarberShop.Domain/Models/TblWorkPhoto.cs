using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

[Index("ImageUrl", Name = "UQ__TblWorkP__372CE60D1D9E51F6", IsUnique = true)]
public partial class TblWorkPhoto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(32)]
    public string? Title { get; set; }

    [StringLength(64)]
    public string ImageUrl { get; set; } = null!;
}
