using System;
using System.Collections.Generic;

namespace CA_DbFirstStreetlifting.Models;

public partial class Routine
{
    public int Id { get; set; }

    public string? FullBody { get; set; }

    public string? UpperBody { get; set; }

    public string? LowerBody { get; set; }

    public string? Push { get; set; }

    public string? Pull { get; set; }

    public string? Legs { get; set; }

    public string? Core { get; set; }

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
