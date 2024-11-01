using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class UniBill
{
    public int UniBillId { get; set; }

    public int FkUnitaz { get; set; }

    public int FkBill { get; set; }

    public int KolvoUnitaz { get; set; }

    public virtual Bill FkBillNavigation { get; set; } = null!;

    public virtual Unitaz FkUnitazNavigation { get; set; } = null!;
}
