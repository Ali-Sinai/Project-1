using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class Suggestion
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public DateTime DateModified { get; set; }

    public int Duration { get; set; }

    public int StartTime { get; set; }

    public bool Status { get; set; }

    public virtual User User { get; set; } = null!;
}
