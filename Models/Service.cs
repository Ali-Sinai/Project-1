using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
