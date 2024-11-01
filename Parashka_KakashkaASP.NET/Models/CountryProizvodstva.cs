using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class CountryProizvodstva
{
    public int CountryProizvodstvaId { get; set; }

    public string CountryProizvodstva1 { get; set; } = null!;

    public virtual ICollection<Unitaz> Unitazs { get; set; } = new List<Unitaz>();
}
