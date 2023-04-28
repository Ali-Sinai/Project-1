using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int Score { get; set; }

    public string? Description { get; set; }

    public string Address { get; set; } = null!;

    public virtual Image? Image { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
