using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int FkTypeOplati { get; set; }

    public int FkClient { get; set; }

    public string DateBill { get; set; } = null!;

    public decimal PriceBill { get; set; }

    public virtual Client FkClientNavigation { get; set; } = null!;

    public virtual TypeOplati FkTypeOplatiNavigation { get; set; } = null!;

    public virtual ICollection<UniBill> UniBills { get; set; } = new List<UniBill>();
}
