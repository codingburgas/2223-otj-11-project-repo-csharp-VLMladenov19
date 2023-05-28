using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class Clothe
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public byte[]? Picture { get; set; }

    public int UserId { get; set; }

    public int? TypeId { get; set; }

    [InverseProperty("Clothe")]
    public virtual ICollection<ClotheColor> ClotheColors { get; set; } = new List<ClotheColor>();

    [InverseProperty("Clothe")]
    public virtual ICollection<OutfitClothe> OutfitClothes { get; set; } = new List<OutfitClothe>();

    [ForeignKey("TypeId")]
    [InverseProperty("Clothes")]
    public virtual Type? Type { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Clothes")]
    public virtual User User { get; set; } = null!;
}
