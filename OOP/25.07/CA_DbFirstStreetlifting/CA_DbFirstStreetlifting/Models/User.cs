using System;
using System.Collections.Generic;

namespace CA_DbFirstStreetlifting.Models;

public partial class User
{
    public int Id { get; set; }

    public string NickName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Measurament> Measuraments { get; set; } = new List<Measurament>();

    public virtual UserDetail? UserDetail { get; set; }
}
