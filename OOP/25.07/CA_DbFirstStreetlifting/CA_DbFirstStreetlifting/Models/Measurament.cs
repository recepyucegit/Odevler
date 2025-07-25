using System;
using System.Collections.Generic;

namespace CA_DbFirstStreetlifting.Models;

public partial class Measurament
{
    public int Id { get; set; }

    public int NeckMeasure { get; set; }

    public int ChestMeasure { get; set; }

    public int BellyMeasure { get; set; }

    public int QuadricepsMeasure { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
