using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public int ServiceId { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Service Service { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
