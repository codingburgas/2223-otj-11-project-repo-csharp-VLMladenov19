using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WardrobeManager.Models;

public partial class Clothe
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Type { get; set; }

    public byte[]? Picture { get; set; }
}
