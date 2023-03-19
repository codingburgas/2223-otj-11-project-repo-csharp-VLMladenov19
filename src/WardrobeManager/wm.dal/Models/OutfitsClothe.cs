﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

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

    [Key]
    public int Id { get; set; }

    public int? OutfitId { get; set; }

    public int? ClotheId { get; set; }

    [ForeignKey("ClotheId")]
    [InverseProperty("OutfitsClothes")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("OutfitId")]
    [InverseProperty("OutfitsClothes")]
    public virtual Outfit? Outfit { get; set; }
}
