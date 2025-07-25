using System;
using System.Collections.Generic;

namespace CA_DbFirstStreetlifting.Models;

public partial class UserDetail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
