using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Index("Name", Name = "UQ__Colors__737584F6727F5ADA", IsUnique = true)]
public partial class Color
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Color")]
    public virtual ICollection<ClotheColor> ClotheColors { get; set; } = new List<ClotheColor>();
}
