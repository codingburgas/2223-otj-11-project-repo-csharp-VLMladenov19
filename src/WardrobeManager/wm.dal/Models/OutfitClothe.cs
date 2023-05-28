using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class OutfitClothe
{
    [Key]
    public int Id { get; set; }

    public int? OutfitId { get; set; }

    public int? ClotheId { get; set; }

    [ForeignKey("ClotheId")]
    [InverseProperty("OutfitClothes")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("OutfitId")]
    [InverseProperty("OutfitClothes")]
    public virtual Outfit? Outfit { get; set; }
}
