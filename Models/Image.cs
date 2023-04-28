using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Image
{
    public int Id { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime? DateModified { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
