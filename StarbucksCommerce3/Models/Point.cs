using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Point
{
    public int PointId { get; set; }

    public int MemberId { get; set; }

    public int? TotalPoint { get; set; }

    public virtual Member Member { get; set; } = null!;
}
