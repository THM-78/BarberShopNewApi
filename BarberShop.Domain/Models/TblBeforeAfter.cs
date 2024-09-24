using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Domain.Models;

public partial class TblBeforeAfter
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(64)]
    public string BeforeImgUrl { get; set; } = null!;

    [StringLength(64)]
    public string AfterImgUrl { get; set; } = null!;
}
