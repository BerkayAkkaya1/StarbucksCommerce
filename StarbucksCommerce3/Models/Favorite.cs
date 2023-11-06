using System;
using System.Collections.Generic;

namespace StarbucksCommerce3.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int MemberId { get; set; }

    public int ProductId { get; set; }

    public DateTime FavoriteDate { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
