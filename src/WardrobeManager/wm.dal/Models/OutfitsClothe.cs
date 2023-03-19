using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Keyless]
public partial class OutfitsClothe
{
    public int? OutfitId { get; set; }

    public int? ClotheId { get; set; }

    [ForeignKey("ClotheId")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("OutfitId")]
    public virtual Outfit? Outfit { get; set; }
}
