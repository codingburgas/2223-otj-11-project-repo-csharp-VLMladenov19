﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wm.dal.Models;

[Index("Username", Name = "UQ__Users__536C85E4B79D4E24", IsUnique = true)]
public partial class User
{
    public User()
    {
    }

    public User(string username, string password, string firstName, string lastName, string phone, string email)
    {
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Salt { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Clothe> Clothes { get; } = new List<Clothe>();

    [InverseProperty("User")]
    public virtual ICollection<Outfit> Outfits { get; } = new List<Outfit>();
}
