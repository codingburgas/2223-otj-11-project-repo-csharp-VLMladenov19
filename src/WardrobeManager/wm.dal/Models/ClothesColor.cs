using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Keyless]
public partial class ClothesColor
{
    public int? ClotheId { get; set; }

    public int? ColorId { get; set; }

    [ForeignKey("ClotheId")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("ColorId")]
    public virtual Color? Color { get; set; }
}
