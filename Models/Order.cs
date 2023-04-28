using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DateModified { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
