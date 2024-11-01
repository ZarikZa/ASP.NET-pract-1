using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class UnitazType
{
    public int UnitazTypeId { get; set; }

    public string UnitazType1 { get; set; } = null!;

    public virtual ICollection<Unitaz> Unitazs { get; set; } = new List<Unitaz>();
}
