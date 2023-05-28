using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Index("Name", Name = "UQ__Types__737584F609CBCE27", IsUnique = true)]
public partial class Type
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<Clothe> Clothes { get; set; } = new List<Clothe>();
}
