using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class Outfit
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    [InverseProperty("Outfit")]
    public virtual ICollection<OutfitsClothe> OutfitsClothes { get; } = new List<OutfitsClothe>();

    [ForeignKey("UserId")]
    [InverseProperty("Outfits")]
    public virtual User User { get; set; } = null!;
}
