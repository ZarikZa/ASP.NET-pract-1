using System;
using System.Collections.Generic;

namespace Parashka_KakashkaASP.NET.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientSurname { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string? ClientMiddleName { get; set; }

    public string Loginn { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
