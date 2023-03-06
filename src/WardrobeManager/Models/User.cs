using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WardrobeManager.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    public long? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? LibraryId { get; set; }

    [ForeignKey("LibraryId")]
    [InverseProperty("Users")]
    public virtual Library? Library { get; set; }
}
