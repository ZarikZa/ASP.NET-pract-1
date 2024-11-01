using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class Unitaz
{
    public int UnitazId { get; set; }

    public string UnitazName { get; set; } = null!;

    public string Img { get; set; } = null!;

    public string Infa { get; set; } = null!;

    public int FkUnitazType { get; set; }

    public decimal UnitazPrice { get; set; }

    public int FkCountryProizvodstva { get; set; }

    public virtual CountryProizvodstva FkCountryProizvodstvaNavigation { get; set; } = null!;

    public virtual UnitazType FkUnitazTypeNavigation { get; set; } = null!;

    public virtual ICollection<UniBill> UniBills { get; set; } = new List<UniBill>();
}
