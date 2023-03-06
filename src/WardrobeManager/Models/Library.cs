using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WardrobeManager.Models;

public partial class Library
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("Library")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
