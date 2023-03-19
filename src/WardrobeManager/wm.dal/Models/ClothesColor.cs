using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class ClothesColor
{
    public ClothesColor()
    {
    }

    public ClothesColor(int clotheId, int colorId, Clothe clothe, Color color)
    {
        ClotheId = clotheId;
        ColorId = colorId;
        Clothe = clothe;
        Color = color;
    }

    [Key]
    public int Id { get; set; }

    public int? ClotheId { get; set; }

    public int? ColorId { get; set; }

    [ForeignKey("ClotheId")]
    [InverseProperty("ClothesColors")]
    public virtual Clothe? Clothe { get; set; }

    [ForeignKey("ColorId")]
    [InverseProperty("ClothesColors")]
    public virtual Color? Color { get; set; }
}
