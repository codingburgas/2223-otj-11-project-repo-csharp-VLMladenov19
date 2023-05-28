using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class ClotheColor
{
    [Key]
    public int Id { get; set; }

    public int? ClotheId { get; set; }

    public int? ColorId { get; set; }

    [ForeignKey("ClotheId")]
    [InverseProperty("ClotheColors")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("ColorId")]
    [InverseProperty("ClotheColors")]
    public virtual Color? Color { get; set; }
}
