using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class TypeOplati
{
    public int TypeOplatiId { get; set; }

    public string TypeOplati1 { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
