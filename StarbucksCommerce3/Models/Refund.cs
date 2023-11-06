using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Refund
{
    public int ReturnId { get; set; }

    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public string ReturnDescription { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
