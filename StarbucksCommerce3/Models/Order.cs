using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public int ProductId { get; set; }

    public string OrderDate { get; set; } = null!;

    public int OrderQuantity { get; set; }

    public decimal OrderPrice { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
}
