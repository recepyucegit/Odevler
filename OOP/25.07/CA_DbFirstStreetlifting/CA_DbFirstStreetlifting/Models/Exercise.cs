using System;
using System.Collections.Generic;

namespace CA_DbFirstStreetlifting.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public string? DeadLift { get; set; }

    public string? Squat { get; set; }

    public string? BenchPress { get; set; }

    public string? OverHeadPress { get; set; }

    public string? PullUp { get; set; }

    public string? Dip { get; set; }

    public string? Row { get; set; }

    public string? PushUp { get; set; }

    public string? HollowBodyHold { get; set; }

    public string? Plank { get; set; }

    public string? LegRaise { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
