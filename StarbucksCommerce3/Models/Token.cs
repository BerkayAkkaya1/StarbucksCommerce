using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Token
{
    public int GiftTokenId { get; set; }

    public DateTime ExpDate { get; set; }

    public decimal TokenAmount { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;
}
