using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

public partial class Clothe
{
    public Clothe()
    {
    }

    public Clothe(string name, int userId, int typeId)
    {
        Name = name;
        UserId = userId;
        TypeId = typeId;
    }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public byte[]? Picture { get; set; }

    public int UserId { get; set; }

    public int? TypeId { get; set; }

    [ForeignKey("TypeId")]
    [InverseProperty("Clothes")]
    public virtual Type? Type { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Clothes")]
    public virtual User User { get; set; } = null!;
}
