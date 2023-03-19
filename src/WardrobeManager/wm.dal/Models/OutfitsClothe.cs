using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Keyless]
public partial class OutfitsClothe
{
    public OutfitsClothe()
    {
    }

    public OutfitsClothe(int clotheId, int outfitId, Clothe clothe, Outfit outfit)
    {
        ClotheId = clotheId;
        OutfitId = outfitId;
        Clothe = clothe;
        Outfit = outfit;
    }

    public int? ClotheId { get; set; }

    public int? OutfitId { get; set; }

    [ForeignKey("ClotheId")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("OutfitId")]
    public virtual Outfit? Outfit { get; set; }
}
